namespace SistemaDeReservas.API.Dtos.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        public string País { get; set; }
        public int Estrellas { get; set; }
        public string Teléfono { get; set; }
        public string Email { get; set; }
    }
}
