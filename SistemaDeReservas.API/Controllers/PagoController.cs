using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.API.Dtos.Pagos;
using SistemaDeReservas.API.Services;
using SistemaDeReservas.API.Services.Interfaces;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/Pago")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _pagoService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _pagoService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PagoCreateDto dto)
        {
            var response = await _pagoService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] PagoEditDto dto)
        {
            var response = await _pagoService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _pagoService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}