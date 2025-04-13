using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.ServiciosAdicionales
{
    public class ServicioAdicionalCreateDto
    {
        [Required(ErrorMessage = "El nombre del servicio es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Nombre { get; set; }

        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La disponibilidad es obligatoria")]
        public bool Disponible { get; set; }
    }
}