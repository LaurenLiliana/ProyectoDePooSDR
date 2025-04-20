using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("servicio_adicional")]
    public class ServicioAdicionalEntity
    {
        [Key]
        [Column("servicio_adicional_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicioAdicionalId { get; set; }

        //[Column("reserva_id")]
        //[Required]
        //public int ReservaId { get; set; }

        [Column("nombre")]
        [Required]
        public string Nombre { get; set; }

        [Column("descripcion")]
        public string Descripción { get; set; }

        [Column("precio")]
        [Required]
        public decimal Precio { get; set; }

        [Column("disponible")]
        [Required]
        public bool Disponible { get; set; }

        //[ForeignKey(nameof(ReservaId))]
        //public ReservaEntity Reserva { get; set; }
    }

}
