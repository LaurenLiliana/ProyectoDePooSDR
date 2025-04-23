namespace SistemaDeReservas.API.Dtos.Pagos
{
    public class PagoActionResponseDto
    {
        public int ReservaId { get; set; }
        public string Estado { get; set; }
        public string Metodo { get; set; }
    }
}