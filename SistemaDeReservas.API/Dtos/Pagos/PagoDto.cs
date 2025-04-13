using System;

namespace SistemaDeReservas.API.Dtos.Pagos
{
    public class PagoDto
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public string Metodo { get; set; }
        public DateTime FechaPago { get; set; }
        public string Estado { get; set; }
    }
}