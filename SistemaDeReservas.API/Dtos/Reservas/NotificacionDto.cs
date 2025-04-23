namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class NotificacionDto
    {
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public string Destinatario { get; set; }
    }

}
