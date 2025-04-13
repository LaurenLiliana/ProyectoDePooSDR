using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Reservas { 
    public class ReservaCreateDto
    {
        [Required(ErrorMessage = "El ID del cliente es obligatorio")]
        public string ClienteId { get; set; }

        [Required(ErrorMessage = "El ID de la habitación es obligatorio")]
        public int HabitacionId { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateTime FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateTime FechaFin { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Estado { get; set; } //Confirmada o cancelada
    }
}