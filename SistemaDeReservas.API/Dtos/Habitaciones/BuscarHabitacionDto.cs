namespace SistemaDeReservas.API.Dtos.Habitaciones
{
    public class BuscarHabitacionesDto
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Tipo { get; set; }  // Ejemplo: "Individual", "Doble", "Suite"
        public int Capacidad { get; set; }
        public decimal PrecioMinimo { get; set; }
        public decimal PrecioMaximo { get; set; }

        public bool OrdenarPorPrecio { get; set; }
    }

}
