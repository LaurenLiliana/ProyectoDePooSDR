using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Services.Interfaces;

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
                    .Include(h => h.Hotel)  // Carga relacionada si es necesario
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
                    Message = $"Error al obtener habitaciones: {ex.Message}",
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
                    .FirstOrDefaultAsync(h => h.Id == id);

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
                    Message = $"Error al obtener habitación: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HabitacionActionResponseDto>> CreateAsync(HabitacionCreateDto dto)
        {
            try
            {
                // Validar número único por hotel
                var existeNumero = await _context.Habitaciones
                    .AnyAsync(h => h.HotelId == dto.HotelId && h.Numero == dto.Numero);

                if (existeNumero)
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
            catch (DbUpdateException ex)
            {
                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al crear habitación: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error interno: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<HabitacionActionResponseDto>> EditAsync(int id, HabitacionEditDto dto)
        {
            try
            {
                // Obtener la habitación existente
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

                // Validar número único si cambió
                if (habitacion.Numero != dto.Numero)
                {
                    var existeNumero = await _context.Habitaciones
                        .AnyAsync(h => h.HotelId == habitacion.HotelId &&
                                      h.Numero == dto.Numero &&
                                      h.Id != id);
                    if (existeNumero)
                    {
                        return new ResponseDto<HabitacionActionResponseDto>
                        {
                            StatusCode = 400,
                            Status = false,
                            Message = "Ya existe otra habitación con este número en el hotel",
                            Data = null
                        };
                    }
                }

                // Actualizar solo los campos permitidos (excluyendo el Id)
                _mapper.Map(dto, habitacion);
                habitacion.Id = id; // Asegurar que el ID no se modifique

                await _context.SaveChangesAsync();

                return new ResponseDto<HabitacionActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Habitación actualizada exitosamente",
                    Data = _mapper.Map<HabitacionActionResponseDto>(habitacion)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<HabitacionActionResponseDto>
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

                var tieneReservas = await _context.Reservas.AnyAsync(r => r.HabitacionId == id);
                if (tieneReservas)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "No se puede eliminar: La habitación tiene reservas asociadas",
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
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al eliminar: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}
