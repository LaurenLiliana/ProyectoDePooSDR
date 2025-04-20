using SistemaDeReservas.API.Dtos.Reservas;

namespace SistemaDeReservas.API.Dtos.Cliente
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string DocumentoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; } 
    }
}
