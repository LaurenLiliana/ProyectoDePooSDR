using SistemaDeReservas.API.Dtos.Hotel;

namespace SistemaDeReservas.API.Dtos.Habitacion
{
    public class HabitacionActionResponseDto
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }

    }
}
