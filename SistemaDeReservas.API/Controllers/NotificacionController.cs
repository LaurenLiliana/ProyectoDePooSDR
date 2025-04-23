using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Dtos.Reservas;


namespace SistemaDeReservas.API.Controllers
{
    [ApiController]
    [Route("api/notification")]
    public class NotificacionesController : ControllerBase
    {
        private readonly INotificacionService _notificacionService;

        public NotificacionesController(INotificacionService notificacionService)
        {
            _notificacionService = notificacionService;
        }

        [HttpPost("enviar")]
        public async Task<ActionResult> EnviarNotificacion([FromBody] NotificacionDto notificacion)
        {
            var notificacionCreada = _notificacionService.CrearNotificacion(
                notificacion.Titulo,
                notificacion.Mensaje,
                notificacion.Destinatario
            );

            await _notificacionService.EnviarNotificacionAsync(notificacionCreada);

            return Ok(new { mensaje = "Notificación enviada con éxito", detalle = notificacionCreada });
        }
    }

}
