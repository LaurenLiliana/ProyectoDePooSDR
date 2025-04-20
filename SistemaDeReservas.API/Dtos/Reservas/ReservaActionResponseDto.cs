using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Habitaciones;
using SistemaDeReservas.API.Dtos.Pagos;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaActionResponseDto
    {
        public int ReservaId { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal TotalPago { get; set; }
        //public HabitacionActionResponseDto Habitacion { get; set; }
        public HabitacionActionResponseDtoDos Habitacion { get; set; }
        public PagoEstadoDto Pago { get; set; }
        public ServicioAdicionalDisponibleDto ServicioAdicional { get; set; }
    }
}