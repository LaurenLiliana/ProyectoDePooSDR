using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeReservas.API.Database.Entities
{
    [Table("notificaciones")]
    public class NotificacionEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("notificacion_id")]
        public int NotificacionId { get; set; }

        [Required]
        [Column("titulo")]
        public string Titulo { get; set; }

        [Required]
        [Column("mensaje")]
        public string Mensaje { get; set; }

        [Required]
        [Column("fecha_envio")]
        public DateTime FechaEnvio { get; set; }

        [Required]
        [Column("destinatario")]
        public string Destinatario { get; set; }
    }
}
