using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Services.Interfaces;
using Persons.API.Dtos.Common;

namespace SistemaDeReservas.API.Services
{
    public class HabitacionService : IHabitacionService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public HabitacionService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<HabitacionDto>>> GetListAsync()
        {
            try
            {
                var habitaciones = await _context.Habitaciones
                    .Include(h => h.Hotel) 
                    .ToListAsync();

                return new ResponseDto<List<HabitacionDto>>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Lista de habitaciones obtenida",
                    Data = _mapper.Map<List<HabitacionDto>>(habitaciones)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<List<HabitacionDto>>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HabitacionDto>> GetByIdAsync(int id)
        {
            try
            {
                var habitacion = await _context.Habitaciones
                  .Include(h => h.Hotel) 
                  .FirstOrDefaultAsync(h => h.HabitacionId == id);

                if (habitacion == null)
                {
                    return new ResponseDto<HabitacionDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Habitación no encontrada",
                        Data = null
                    };
                }

                return new ResponseDto<HabitacionDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Habitación obtenida",
                    Data = _mapper.Map<HabitacionDto>(habitacion)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<HabitacionDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HabitacionActionResponseDto>> CreateAsync(HabitacionCreateDto dto)
        {
            try
            {
                
                var hotelExiste = await _context.Hoteles.AnyAsync(h => h.HotelId == dto.HotelId);
                if (!hotelExiste)
                {
                    return new ResponseDto<HabitacionActionResponseDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "El hotel especificado no existe",
                        Data = null
                    };
                }

                var numeroRepetido = await _context.Habitaciones
                    .AnyAsync(h => h.HotelId == dto.HotelId && h.Numero == dto.Numero);

                if (numeroRepetido)
                {
                    return new ResponseDto<HabitacionActionResponseDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "Ya existe una habitación con este número en el hotel",
                        Data = null
                    };
                }

                var habitacion = _mapper.Map<HabitacionEntity>(dto);
                _context.Habitaciones.Add(habitacion);
                await _context.SaveChangesAsync();

                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Habitación creada exitosamente",
                    Data = _mapper.Map<HabitacionActionResponseDto>(habitacion)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HabitacionActionResponseDto>> EditAsync(int id, HabitacionEditDto dto)
        {
            try
            {
                var habitacion = await _context.Habitaciones.FindAsync(id);
                if (habitacion == null)
                {
                    return new ResponseDto<HabitacionActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Habitación no encontrada",
                        Data = null
                    };
                }

           
                if (habitacion.Numero != dto.Numero)
                {
                    var existeNumero = await _context.Habitaciones
                        .AnyAsync(h => h.HotelId == dto.HotelId &&
                                       h.Numero == dto.Numero &&
                                       h.HabitacionId != id);
                    if (existeNumero)
                    {
                        return new ResponseDto<HabitacionActionResponseDto>
                        {
                            StatusCode = 400,
                            Status = false,
                            Message = "El número de habitación ya está en uso",
                            Data = null
                        };
                    }
                }

                _mapper.Map(dto, habitacion);
                await _context.SaveChangesAsync();

                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Habitación actualizada",
                    Data = _mapper.Map<HabitacionActionResponseDto>(habitacion)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var habitacion = await _context.Habitaciones.FindAsync(id);
                if (habitacion == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Habitación no encontrada",
                        Data = false
                    };
                }

                var hoy = DateOnly.FromDateTime(DateTime.Today);
                var tieneReservas = await _context.Reservas
                    .AnyAsync(r => r.HabitacionId == id && r.FechaFin >= hoy);

                if (tieneReservas)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "No se puede eliminar: Hay reservas futuras para esta habitación",
                        Data = false
                    };
                }

                _context.Habitaciones.Remove(habitacion);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Habitación eliminada",
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error: {ex.Message}",
                    Data = false
                };
            }
        }
    }
}