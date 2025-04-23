using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("reservas")]
    public class ReservaEntity
    {
        [Key]
        [Column("reserva_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservaId { get; set; }

        [Column("cliente_id")]
        [Required]
        public int ClienteId { get; set; }

        [Column("habitacion_id")]
        [Required]
        public int HabitacionId { get; set; }

        [Column("fechaInicio")]
        [Required]
        public DateOnly FechaInicio { get; set; }

        [Column("fechaFin")]
        [Required]
        public DateOnly FechaFin { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

        [Column("total_pago")]
        [Required]
        public decimal TotalPago { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual ClienteEntity Cliente { get; set; }

        [ForeignKey(nameof(HabitacionId))]
        public virtual HabitacionEntity Habitacion { get; set; }
        public virtual List<PagoEntity> Pagos { get; set; }
        public virtual List<ServicioAdicionalEntity> ServiciosAdicionales { get; set; }

    }

}
