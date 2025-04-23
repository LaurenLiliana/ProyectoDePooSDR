using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Database;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Dtos.Reservas;

namespace SistemaDeReservas.API.Services
{
    public class NotificacionService : INotificacionService
    {
        private readonly ApiDbContext _context;

        public NotificacionService(ApiDbContext context)
        {
            _context = context;
        }


        public NotificacionDto CrearNotificacion(string titulo, string mensaje, string destinatario)
        {
            var notificacionEntity = new NotificacionEntity
            {
                Titulo = titulo,
                Mensaje = mensaje,
                FechaEnvio = DateTime.Now,
                Destinatario = destinatario
            };


            _context.Notificaciones.Add(notificacionEntity);
            _context.SaveChanges();

            var notificacionDto = new NotificacionDto
            {
                Titulo = titulo,
                Mensaje = mensaje,
                Fecha = DateTime.Now,
                Destinatario = destinatario
            };

            return notificacionDto;
        }

        public async Task EnviarNotificacionAsync(NotificacionDto notificacion)
        {
            await Task.Delay(100);
            Console.WriteLine($"Notificación enviada: {notificacion.Titulo} - {notificacion.Mensaje}");
        }
    }

}
