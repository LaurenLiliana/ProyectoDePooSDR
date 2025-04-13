namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public int HabitacionId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public decimal TotalPago { get; set; }
    }
}
