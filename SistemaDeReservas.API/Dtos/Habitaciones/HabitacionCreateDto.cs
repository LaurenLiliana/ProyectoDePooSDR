using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Habitacion
{
    public class HabitacionCreateDto
    {
        [Required(ErrorMessage = "El número de habitación es obligatorio")]
        [StringLength(10, ErrorMessage = "El número no puede exceder 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El tipo de habitación es obligatorio")]
        public string Tipo { get; set; } //Individual, doble o suite

        [Required(ErrorMessage = "El precio por noche es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal PrecioPorNoche { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 10, ErrorMessage = "La capacidad debe ser entre 1 y 10")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El ID del hotel es obligatorio")]
        public int HotelId { get; set; }
    }
}