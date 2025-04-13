using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Pagos
{
    public class PagoCreateDto
    {
        [Required(ErrorMessage = "El ID de la reserva es obligatorio")]
        public int ReservaId { get; set; }

        [Required(ErrorMessage = "El método de pago es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string Metodo { get; set; } // (Tarjeta, efectivo, transferencia

        [Required(ErrorMessage = "La fecha de pago es obligatoria")]
        public DateTime FechaPago { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El estado es obligatorio")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Estado { get; set; } //Completado, fallido o pendiente
    }
}