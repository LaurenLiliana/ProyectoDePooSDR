using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;
using SistemaDeReservas.API.Services.Interfaces;
using Persons.API.Dtos.Common;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/ServicioAdicional")]
    [ApiController]
    public class ServiciosAdicionalesController : ControllerBase
    {
        private readonly IServicioAdicionalService _servicioService;

        public ServiciosAdicionalesController(IServicioAdicionalService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ServicioAdicionalDto>>>> GetAll()
        {
            var response = await _servicioService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ServicioAdicionalDto>>> GetById(int id)
        {
            var response = await _servicioService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ServicioAdicionalActionResponseDto>>> Create([FromBody] ServicioAdicionalCreateDto dto)
        {
            var response = await _servicioService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ServicioAdicionalActionResponseDto>>> Edit(int id, [FromBody] ServicioAdicionalEditDto dto)
        {
            var response = await _servicioService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(int id)
        {
            var response = await _servicioService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}