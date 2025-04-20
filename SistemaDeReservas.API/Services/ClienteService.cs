using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Clientes;
using Persons.API.Dtos.Common;

namespace SistemaDeReservas.API.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ClienteService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ClienteActionResponseDto>> GetByIdAsync(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Reservas)
                    .ThenInclude(r => r.Habitacion)
                        .ThenInclude(h => h.Hotel)
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente == null)
            {
                return new ResponseDto<ClienteActionResponseDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Cliente no encontrado",
                    Data = null
                };
            }

            // Calculo del Pago 
            foreach (var reserva in cliente.Reservas)
            {
                int dias = (reserva.FechaFin.DayNumber - reserva.FechaInicio.DayNumber);
                reserva.TotalPago = dias * reserva.Habitacion.PrecioPorNoche;
            }

            return new ResponseDto<ClienteActionResponseDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Cliente obtenido exitosamente",
                Data = _mapper.Map<ClienteActionResponseDto>(cliente)
            };
        }


        public async Task<ResponseDto<List<ClienteActionResponseDto>>> GetAllAsync()
        {
            var clientes = await _context.Clientes.ToListAsync();

            return new ResponseDto<List<ClienteActionResponseDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de clientes obtenida",
                Data = _mapper.Map<List<ClienteActionResponseDto>>(clientes)
            };
        }


        public async Task<ResponseDto<ClienteActionResponseDto>> CreateAsync(ClienteCreateDto dto)
        {
            try
            {
                var existeDocumento = await _context.Clientes.AnyAsync(c => c.DocumentoId == dto.DocumentoId);
                if (existeDocumento)
                {
                    return new ResponseDto<ClienteActionResponseDto>
                    {
                        StatusCode = 400,
                        Status = false,
                        Message = "Ya existe un cliente con este documento",
                        Data = null
                    };
                }

                var cliente = _mapper.Map<ClienteEntity>(dto);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return new ResponseDto<ClienteActionResponseDto>
                {
                    StatusCode = 201,
                    Status = true,
                    Message = "Cliente creado exitosamente",
                    Data = _mapper.Map<ClienteActionResponseDto>(cliente)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ClienteActionResponseDto>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al crear cliente: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }


        public async Task<ResponseDto<ClienteActionResponseDto>> EditAsync(int id, ClienteEditDto dto)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return new ResponseDto<ClienteActionResponseDto>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Cliente no encontrado",
                        Data = null
                    };
                }

                cliente.Nombre = dto.Nombre;
                cliente.Apellido = dto.Apellido;
                cliente.Telefono = dto.Telefono;

                await _context.SaveChangesAsync();

                return new ResponseDto<ClienteActionResponseDto>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Cliente actualizado",
                    Data = _mapper.Map<ClienteActionResponseDto>(cliente)
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<ClienteActionResponseDto>
                {
                    StatusCode = 400,
                    Status = false,
                    Message = $"Error al actualizar cliente: {ex.InnerException?.Message ?? ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return new ResponseDto<bool>
                    {
                        StatusCode = 404,
                        Status = false,
                        Message = "Cliente no encontrado",
                        Data = false
                    };
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

                return new ResponseDto<bool>
                {
                    StatusCode = 200,
                    Status = true,
                    Message = "Cliente eliminado",
                    Data = true
                };
            }
            catch (DbUpdateException ex)
            {
                return new ResponseDto<bool>
                {
                    StatusCode = 500,
                    Status = false,
                    Message = $"Error al eliminar cliente: {ex.InnerException?.Message ?? ex.Message}",
                    Data = false
                };
            }
        }
    }
}