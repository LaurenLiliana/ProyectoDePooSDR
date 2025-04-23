using System.ComponentModel.DataAnnotations;

public class ClienteCreateDto
{
    [Required(ErrorMessage = "El documento es obligatorio")]
    [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
    public string DocumentoId { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [StringLength(8, ErrorMessage = "Máximo 8 caracteres")]
    public string Telefono { get; set; } 
}