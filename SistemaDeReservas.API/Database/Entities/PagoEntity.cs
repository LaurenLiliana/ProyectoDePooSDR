using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("pagos")]
    public class PagoEntity
    {
        [Key]
        [Column("pago_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PagoId { get; set; }

        //[Column("reserva_id")]
        //[Required]
        //public int ReservaId { get; set; }

        [Column("metodo_pago")]
        [Required]
        public string MetodoPago { get; set; }

        [Column("fecha_pago")]
        [Required]
        public DateOnly FechaPago { get; set; }

        [Column("estado")]
        [Required]
        public string Estado { get; set; }

        //[ForeignKey(nameof(ReservaId))]
        //public ReservaEntity Reserva { get; set; }
    }

}
