using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Habitaciones;

namespace SistemaDeReservas.API.Dtos.Hotel
{
    public class HotelActionResponseDto
    {
        public int HotelId { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public List<HabitacionActionResponseDto> Habitaciones { get; set; }
    }
}