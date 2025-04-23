using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.API.Services.Interfaces;
using SistemaDeReservas.API.Database.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/reservas-canceladas")]
    [ApiController]
    public class ReservaCanceladaController : ControllerBase
    {
        private readonly IReservaCanceladaService _reservaCanceladaService;

        public ReservaCanceladaController(IReservaCanceladaService reservaCanceladaService)
        {
            _reservaCanceladaService = reservaCanceladaService;
        }

        [HttpPost("cancelar/{id}")]
        public async Task<IActionResult> CancelarReserva(int id)
        {
            await _reservaCanceladaService.CancelarReserva(id);
            return Ok(new { message = "Reserva cancelada exitosamente." });
        }

        [HttpGet("historial/{clienteId}")]
        public async Task<ActionResult<List<ReservaCanceladaEntity>>> ObtenerHistorial(int clienteId)
        {
            var historial = await _reservaCanceladaService.ObtenerHistorial(clienteId);
            return Ok(historial);
        }
    }
}
