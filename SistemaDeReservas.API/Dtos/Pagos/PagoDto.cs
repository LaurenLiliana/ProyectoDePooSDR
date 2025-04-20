using System;

namespace SistemaDeReservas.API.Dtos.Pagos
{
    public class PagoDto
    {
        public int ReservaId { get; set; }
        public string MetodoPago { get; set; }
        public DateOnly FechaPago { get; set; }
        public string Estado { get; set; }
    }
}