using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Habitacion
{
    public class HabitacionCreateDto
    {
        [Required(ErrorMessage = "El número es obligatorio")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser positivo")]
        public decimal PrecioPorNoche { get; set; }

        [Required(ErrorMessage = "La capacidad es obligatoria")]
        [Range(1, 10, ErrorMessage = "La capacidad debe ser entre 1 y 10")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "La disponibilidad es obligatoria")]
        public bool Disponible { get; set; }

        public string Descripción { get; set; }

        [Required(ErrorMessage = "El ID del hotel es obligatorio")]
        public int HotelId { get; set; }
    }
}