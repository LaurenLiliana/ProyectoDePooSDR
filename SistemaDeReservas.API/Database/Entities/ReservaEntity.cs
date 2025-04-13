using SistemaDeReservas.API.Database.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("reservas")]
    public class ReservaEntity : BaseEntity
    {
        [Column("cliente_id")]
        [Required]
        public int ClienteId { get; set; }

        [Column("habitacion_id")]
        [Required]
        public int HabitaciónId { get; set; }

        [Column("FechaInicio")]
        [Required]
        public DateTime FechaInicio { get; set; }

        [Column("FechaFin")]
        [Required]
        public DateTime FechaFin { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

        [Column("total_pago")]
        [Required]
        public decimal TotalPago { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public virtual ClienteEntity Cliente { get; set; }

        [ForeignKey(nameof(HabitaciónId))]
        public virtual HabitacionEntity Habitación { get; set; }

        public virtual ICollection<PagoEntity> Pagos { get; set; }
    }
}
