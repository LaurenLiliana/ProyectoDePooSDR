using Microsoft.AspNetCore.Mvc;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Services.Interfaces;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Clientes;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/Clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ClienteDto>>>> GetAll()
        {
            var response = await _clienteService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ClienteDto>>> GetById(int id)
        {
            var response = await _clienteService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<ClienteActionResponseDto>>> Create([FromBody] ClienteCreateDto dto)
        {
            var response = await _clienteService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ClienteActionResponseDto>>> Edit(
            int id,
            [FromBody] ClienteEditDto dto)
        {
            var response = await _clienteService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(int id)
        {
            var response = await _clienteService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}