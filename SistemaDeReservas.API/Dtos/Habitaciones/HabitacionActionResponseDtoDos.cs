using SistemaDeReservas.API.Dtos.Hotel;

namespace SistemaDeReservas.API.Dtos.Habitaciones
{
    public class HabitacionActionResponseDtoDos
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public HotelParaHabitacionDto Hotel { get; set; }

    }
}
