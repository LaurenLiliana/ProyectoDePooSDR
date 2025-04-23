// ServicioAdicionalService.cs
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Database.Entities;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales.SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Services
{
    public class ServicioAdicionalService : IServicioAdicionalService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ServicioAdicionalService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ServicioAdicionalDto>> GetByIdAsync(int id)
        {
            var servicio = await _context.ServiciosAdicionales.FindAsync(id);
            if (servicio == null)
            {
                return new ResponseDto<ServicioAdicionalDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Servicio no encontrado",
                    Data = null
                };
            }

            return new ResponseDto<ServicioAdicionalDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Servicio obtenido",
                Data = _mapper.Map<ServicioAdicionalDto>(servicio)
            };
        }

        public async Task<ResponseDto<List<ServicioAdicionalDto>>> GetAllAsync()
        {
            var servicios = await _context.ServiciosAdicionales.ToListAsync();
            return new ResponseDto<List<ServicioAdicionalDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de servicios obtenida",
                Data = _mapper.Map<List<ServicioAdicionalDto>>(servicios)
            };
        }

        public async Task<ResponseDto<ServicioAdicionalActionResponseDto>> CreateAsync(ServicioAdicionalCreateDto dto)
        {
            try
            {
                var servicio = _mapper.Map<ServicioAdicionalEntity>(dto);
                _context.ServiciosAdicionales.Add(servicio);
                await _context.SaveChangesAsync();

                return new ResponseDto<ServicioAdicionalActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Servicio creado exitosamente",
                    Data = _mapper.Map<ServicioAdicionalActionResponseDto>(servicio)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ServicioAdicionalActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al crear servicio: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<ServicioAdicionalActionResponseDto>> EditAsync(int id, ServicioAdicionalEditDto dto)
        {
            try
            {
                var servicio = await _context.ServiciosAdicionales.FindAsync(id);
                if (servicio == null)
                {
                    return new ResponseDto<ServicioAdicionalActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Servicio no encontrado",
                        Data = null
                    };
                }

                _mapper.Map(dto, servicio);
                await _context.SaveChangesAsync();

                return new ResponseDto<ServicioAdicionalActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Servicio actualizado",
                    Data = _mapper.Map<ServicioAdicionalActionResponseDto>(servicio)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ServicioAdicionalActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al actualizar servicio: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var servicio = await _context.ServiciosAdicionales.FindAsync(id);
                if (servicio == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Servicio no encontrado",
                        Data = false
                    };
                }

                _context.ServiciosAdicionales.Remove(servicio);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Servicio eliminado",
                    Data = true
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al eliminar servicio: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}