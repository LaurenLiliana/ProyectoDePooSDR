using SistemaDeReservas.API.Dtos.ServiciosAdicionales;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.ServiciosAdicionales
{
    public class ServicioAdicionalEditDto : ServicioAdicionalCreateDto
    {
        [Required(ErrorMessage = "El ID del servicio es obligatorio")]
        public int Id { get; set; }
    }
}