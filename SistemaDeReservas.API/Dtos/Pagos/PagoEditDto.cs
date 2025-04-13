using SistemaDeReservas.API.Dtos.Pagos;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Pagos
{
    public class PagoEditDto : PagoCreateDto
    {
        [Required(ErrorMessage = "El ID del pago es obligatorio")]
        public int Id { get; set; }
    }
}