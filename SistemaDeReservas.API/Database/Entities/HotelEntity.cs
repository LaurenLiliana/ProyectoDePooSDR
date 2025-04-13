using SistemaDeReservas.API.Database.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("hoteles")]
    public class HotelEntity : BaseEntity
    {
        [Column("nombre")]
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Column("direccion")]
        [Required]
        [MaxLength(200)]
        public string Dirección { get; set; }

        [Column("ciudad")]
        [Required]
        public string Ciudad { get; set; }

        [Column("pais")]
        [Required]
        public string País { get; set; }

        [Column("estrellas")]
        [Range(1, 5)]
        public int Estrellas { get; set; }

        [Column("telefono")]
        [Required]
        public string Teléfono { get; set; }

        [Column("email")]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<HabitacionEntity> Habitaciones { get; set; }
    }

}

