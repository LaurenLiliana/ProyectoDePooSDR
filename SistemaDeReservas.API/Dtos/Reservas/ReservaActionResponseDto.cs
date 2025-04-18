using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaActionResponseDto
    {
        public int ReservaId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public HabitacionActionResponseDto Habitacion { get; set; }
        public List<ServicioAdicionalActionResponseDto> Servicios { get; set; } = new();
    }
}