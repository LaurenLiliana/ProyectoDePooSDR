using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Database.Entities;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Reservas;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Dtos.Pagos;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Services
{
    public class ReservaService : IReservaService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ReservaService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ResponseDto<ReservaActionResponseDto>> GetByIdAsync(int id)
        {
            var reserva = await _context.Reservas
                .Include(r => r.Habitacion)
                    .ThenInclude(h => h.Hotel)
                .FirstOrDefaultAsync(r => r.ReservaId == id);

            if (reserva == null)
            {
                return new ResponseDto<ReservaActionResponseDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Reserva no encontrada",
                    Data = null
                };
            }

            // Calculo Total del Pago
            int dias = (reserva.FechaFin.DayNumber - reserva.FechaInicio.DayNumber);
            reserva.TotalPago = dias * reserva.Habitacion.PrecioPorNoche;

            var reservaDto = _mapper.Map<ReservaActionResponseDto>(reserva);


            return new ResponseDto<ReservaActionResponseDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Reserva obtenida",
                Data = reservaDto
            };
        }

        public async Task<ResponseDto<List<ReservaActionResponseDto>>> GetListAsync()
        {
            var reservas = await _context.Reservas
                .Include(r => r.Habitacion)
                    .ThenInclude(h => h.Hotel)
                .ToListAsync();

            var reservaDtos = _mapper.Map<List<ReservaActionResponseDto>>(reservas);

            return new ResponseDto<List<ReservaActionResponseDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de reservas obtenida",
                Data = reservaDtos
            };
        }


        public async Task<ResponseDto<ReservaActionResponseDto>> CreateAsync(ReservaCreateDto dto)
        {
            try
            {
                if (dto.FechaFin <= dto.FechaInicio)
                {
                    return new ResponseDto<ReservaActionResponseDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "La fecha de fin debe ser posterior a la fecha de inicio.",
                        Data = null
                    };
                }

                var habitacion = await _context.Habitaciones.FirstOrDefaultAsync(h => h.HabitacionId == dto.HabitacionId);
                if (habitacion == null)
                {
                    return new ResponseDto<ReservaActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "La habitación no existe.",
                        Data = null
                    };
                }

                var dias = (dto.FechaFin.DayNumber - dto.FechaInicio.DayNumber);
                var totalPago = dias * habitacion.PrecioPorNoche;

                var reserva = _mapper.Map<ReservaEntity>(dto);
                reserva.TotalPago = totalPago;

                _context.Reservas.Add(reserva);
                await _context.SaveChangesAsync();

                return new ResponseDto<ReservaActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Reserva creada exitosamente",
                    Data = _mapper.Map<ReservaActionResponseDto>(reserva)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ReservaActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al crear reserva: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<ReservaActionResponseDto>> EditAsync(int id, ReservaEditDto dto)
        {
            try
            {
                var reserva = await _context.Reservas.FindAsync(id);
                if (reserva == null)
                {
                    return new ResponseDto<ReservaActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Reserva no encontrada",
                        Data = null
                    };
                }

                _mapper.Map(dto, reserva);
                await _context.SaveChangesAsync();

                return new ResponseDto<ReservaActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Reserva actualizada",
                    Data = _mapper.Map<ReservaActionResponseDto>(reserva)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ReservaActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al actualizar reserva: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var reserva = await _context.Reservas.FindAsync(id);
                if (reserva == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Reserva no encontrada",
                        Data = false
                    };
                }

                _context.Reservas.Remove(reserva);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Reserva eliminada",
                    Data = true
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al eliminar reserva: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}