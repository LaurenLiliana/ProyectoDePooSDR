namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaActionResponseDto
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public string Estado { get; set; }
    }
}