namespace SistemaDeReservas.API.Dtos.ServiciosAdicionales
{
    public class ServicioAdicionalDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Disponible { get; set; }
    }
}