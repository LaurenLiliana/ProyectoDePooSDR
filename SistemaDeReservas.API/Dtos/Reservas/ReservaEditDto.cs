using SistemaDeReservas.API.Dtos.Reservas;
using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Dtos.Reservas
{
    public class ReservaEditDto : ReservaCreateDto
    {
        [Required(ErrorMessage = "El ID de la reserva es obligatorio")]
        public int Id { get; set; }
    }
}