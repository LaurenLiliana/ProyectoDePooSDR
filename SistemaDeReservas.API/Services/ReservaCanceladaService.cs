using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Dtos.Reservas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeReservas.API.Services
{
    public class ReservaCanceladaService : IReservaCanceladaService
    {
        private readonly ApiDbContext _context;
        private readonly IMapper _mapper;

        public ReservaCanceladaService(ApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task CancelarReserva(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {

                var reservaCancelada = _mapper.Map<ReservaCanceladaEntity>(reserva);


                reservaCancelada.Estado = "Cancelada";


                _context.ReservasCanceladas.Add(reservaCancelada);


                _context.Reservas.Remove(reserva);

                await _context.SaveChangesAsync();
            }
        }


        public async Task<List<ReservaCanceladaDto>> ObtenerHistorial(int clienteId)
        {
            var historial = await _context.ReservasCanceladas
                .Where(r => r.ClienteId == clienteId)
                .ToListAsync();


            return _mapper.Map<List<ReservaCanceladaDto>>(historial);
        }
    }
}
