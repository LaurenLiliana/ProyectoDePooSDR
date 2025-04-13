using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Hotel
{
    public class HotelCreateDto
    {
        [Display(Name = "Nombre del Hotel")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} debe tener entre {2} y {1} caracteres")]
        public string Dirección { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "{0} no debe exceder {1} caracteres")]
        public string Ciudad { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "{0} no debe exceder {1} caracteres")]
        public string País { get; set; }

        [Display(Name = "Estrellas")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, 5, ErrorMessage = "{0} debe estar entre {1} y {2}")]
        public int Estrellas { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Phone(ErrorMessage = "Formato de teléfono inválido")]
        public string Teléfono { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }  
    }
}