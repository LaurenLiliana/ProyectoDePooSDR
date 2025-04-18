using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("clientes")]
    public class ClienteEntity 
    {
        [Key] 
        [Column("cliente_id")] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ClienteId { get; set; } 

        [Column("documento_id")]
        [Required]
        public string DocumentoId { get; set; }

        [Column("nombre")]
        [Required]
        public string Nombre { get; set; }

        [Column("apellido")]
        [Required]
        public string Apellido { get; set; }

        [Column("telefono")]
        [Required]
        public string Telefono { get; set; }

        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
