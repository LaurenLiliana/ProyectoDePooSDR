using SistemaDeReservas.API.Dtos.Hotel;

namespace SistemaDeReservas.API.Dtos.Habitacion
{
    public class HabitacionDto
    {
        public int HabitacionId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal PrecioPorNoche { get; set; }
        public int Capacidad { get; set; }
        public bool Disponible { get; set; }

        public List<HotelActionResponseDto> Hotel { get; set; } = new List<HotelActionResponseDto>();
    }
}