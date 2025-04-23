using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeReservas.API.Database.Entities
{
    public class ReservaCanceladaEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("cliente_id")]
        public int ClienteId { get; set; }

        [Required]
        [Column("habitacion_id")]
        public int HabitacionId { get; set; }

        [Required]
        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [Required]
        [Column("estado")]
        public string Estado { get; set; }


        [ForeignKey("ClienteId")]
        public ClienteEntity Cliente { get; set; }

        [ForeignKey("HabitacionId")]
        public HabitacionEntity Habitacion { get; set; }
    }
}
