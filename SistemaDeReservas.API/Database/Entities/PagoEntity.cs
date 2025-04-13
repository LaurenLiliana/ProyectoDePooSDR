using SistemaDeReservas.API.Database.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("pagos")]
    public class PagoEntity : BaseEntity
    {
        [Column("reserva_id")]
        [Required]
        public int ReservaId { get; set; }

        [Column("metodo_pago")]
        [Required]
        public string MetodoPago { get; set; }

        [Column("fecha_pago")]
        [Required]
        public DateTime FechaPago { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

        [ForeignKey(nameof(ReservaId))]
        public virtual ReservaEntity Reserva { get; set; }
    }
}
