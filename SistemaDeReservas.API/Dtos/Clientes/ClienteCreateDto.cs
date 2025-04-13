using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Clientes
{
    public class ClienteCreateDto
    {
        [Required(ErrorMessage = "El documento de identidad es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string DocumentoId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "Formato inválido")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Telefono { get; set; }
    }
}