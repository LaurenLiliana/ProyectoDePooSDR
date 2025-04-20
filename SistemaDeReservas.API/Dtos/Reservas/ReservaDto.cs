using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Hotel;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaDto
    {
        public int ReservaId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public string Estado { get; set; }
        public decimal TotalPago { get; set; }

        public List<HabitacionActionResponseDto> Habitacion { get; set; }
    }
}
