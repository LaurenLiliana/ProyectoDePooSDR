using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Pagos;
using Persons.API.Dtos.Common;
using Microsoft.Data.Sqlite;
using SistemaDeReservas.API.Services.Interfaces;

namespace SistemaDeReservas.API.Services
{
    public class PagoService : IPagoService

    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public PagoService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<PagoDto>> GetByIdAsync(int id)
        {
            var pago = await _context.Pagos.FindAsync(id);

            if (pago == null)
            {
                return new ResponseDto<PagoDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Pago no encontrado",
                    Data = null
                };
            }

            return new ResponseDto<PagoDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Pago obtenido",
                Data = _mapper.Map<PagoDto>(pago)
            };
        }

        public async Task<ResponseDto<List<PagoDto>>> GetAllAsync()
        {
            var pagos = await _context.Pagos.ToListAsync();

            return new ResponseDto<List<PagoDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de pagos obtenida",
                Data = _mapper.Map<List<PagoDto>>(pagos)
            };
        }

        public async Task<ResponseDto<PagoActionResponseDto>> CreateAsync(PagoCreateDto dto)
        {
            try
            {
                if (string.IsNullOrEmpty(dto.MetodoPago))
                {
                    return new ResponseDto<PagoActionResponseDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "El método de pago es requerido",
                        Data = null
                    };
                }

                var pago = _mapper.Map<PagoEntity>(dto);
                _context.Pagos.Add(pago);
                await _context.SaveChangesAsync();

                return new ResponseDto<PagoActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Pago creado exitosamente",
                    Data = _mapper.Map<PagoActionResponseDto>(pago)
                };
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqliteException sqlEx && sqlEx.SqliteErrorCode == 19)
            {
                return new ResponseDto<PagoActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = "Faltan campos requeridos: " + sqlEx.Message,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<PagoActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al crear pago: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<PagoActionResponseDto>> EditAsync(int id, PagoEditDto dto)
        {
            try
            {
                var pago = await _context.Pagos.FindAsync(id);
                if (pago == null)
                {
                    return new ResponseDto<PagoActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Pago no encontrado",
                        Data = null
                    };
                }

                _mapper.Map(dto, pago);
                await _context.SaveChangesAsync();

                return new ResponseDto<PagoActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Pago actualizado",
                    Data = _mapper.Map<PagoActionResponseDto>(pago)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<PagoActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al actualizar pago: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var pago = await _context.Pagos.FindAsync(id);
                if (pago == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Pago no encontrado",
                        Data = false
                    };
                }

                _context.Pagos.Remove(pago);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Pago eliminado",
                    Data = true
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al eliminar pago: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}