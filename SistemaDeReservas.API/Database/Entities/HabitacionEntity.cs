using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("habitaciones")]
    public class HabitacionEntity 
    {
        [Key]
        [Column("habitacion_id")]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int HabitacionId { get; set; }  

        [Column("hotel_id")]
        [Required]
        public int HotelId { get; set; }

        [Column("numero")]
        [Required]
        public string Numero { get; set; }

        [Column("tipo")]
        [Required]
        public string Tipo { get; set; }

        [Column("precio_por_noche")]
        [Required]
        public decimal PrecioPorNoche { get; set; }

        [Column("disponible")]
        [Required]
        public bool Disponible { get; set; }

        [Column("capacity")]
        [Required]
        public int Capacidad { get; set; }

        [Column("description")]
        public string Descripción { get; set; }

        [ForeignKey("HotelId")]
        public virtual HotelEntity Hotel { get; set; }

        public virtual ICollection<ReservaEntity> Reservas { get; set; }
    }
}
