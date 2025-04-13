using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Habitacion
{
    public class HabitacionEditDto : HabitacionCreateDto
    {
        [Required(ErrorMessage = "El ID de la habitación es obligatorio")]
        public int Id { get; set; }
    }
}