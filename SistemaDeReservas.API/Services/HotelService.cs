using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Hotel;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Services.Interfaces;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Habitaciones;

namespace SistemaDeReservas.API.Services
{
    public class HotelService : IHotelService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public HotelService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<HotelActionResponseDto>> GetByIdAsync(int id)
        {
            // Obtener el hotel junto con sus habitaciones usando Include
            var hotel = await _context.Hoteles
                .Include(h => h.Habitaciones) // Incluir las habitaciones asociadas
                .FirstOrDefaultAsync(h => h.HotelId == id); // Buscar el hotel por ID

            if (hotel == null)
            {
                // Si no se encuentra el hotel, devolver un error
                return new ResponseDto<HotelActionResponseDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Hotel no encontrado",
                    Data = null
                };
            }

            // Mapear el hotel a DTO y devolver la respuesta
            return new ResponseDto<HotelActionResponseDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Hotel obtenido",
                Data = _mapper.Map<HotelActionResponseDto>(hotel) // Mapear el hotel con las habitaciones
            };
        }



        public async Task<ResponseDto<List<HotelActionResponseDto>>> GetListAsync()
        {
            var hoteles = await _context.Hoteles
                .Include(h => h.Habitaciones) // Incluir las habitaciones asociadas al hotel
                .ToListAsync();

            return new ResponseDto<List<HotelActionResponseDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de hoteles obtenida",
                Data = _mapper.Map<List<HotelActionResponseDto>>(hoteles)
            };
        }



        public async Task<ResponseDto<HotelActionResponseDto>> CreateAsync(HotelCreateDto dto)
        {
            try
            {
                var hotel = _mapper.Map<HotelEntity>(dto);
                _context.Hoteles.Add(hotel);
                await _context.SaveChangesAsync();

                return new ResponseDto<HotelActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Hotel creado exitosamente",
                    Data = _mapper.Map<HotelActionResponseDto>(hotel)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<HotelActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al crear hotel: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HotelActionResponseDto>> EditAsync(int id, HotelEditDto dto)
        {
            try
            {
                var hotel = await _context.Hoteles.FindAsync(id);
                if (hotel == null)
                {
                    return new ResponseDto<HotelActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Hotel no encontrado",
                        Data = null
                    };
                }

                _mapper.Map(dto, hotel);
                await _context.SaveChangesAsync();

                return new ResponseDto<HotelActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Hotel actualizado exitosamente",
                    Data = _mapper.Map<HotelActionResponseDto>(hotel)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<HotelActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al actualizar: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var hotel = await _context.Hoteles.FindAsync(id);
                if (hotel == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Hotel no encontrado",
                        Data = false
                    };
                }

                _context.Hoteles.Remove(hotel);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Hotel eliminado correctamente",
                    Data = true
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al eliminar hotel: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}