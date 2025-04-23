using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaDeReservas.API.Dtos.Reservas;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IReservaCanceladaService
    {
        Task CancelarReserva(int id);
        Task<List<ReservaCanceladaDto>> ObtenerHistorial(int clienteId);
    }
}