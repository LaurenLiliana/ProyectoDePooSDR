using SistemaDeReservas.API.Dtos.Reservas;
namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface INotificacionService
    {
        NotificacionDto CrearNotificacion(string titulo, string mensaje, string destinatario);
        Task EnviarNotificacionAsync(NotificacionDto notificacion);
    }

}
