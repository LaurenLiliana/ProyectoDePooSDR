//using Microsoft.AspNetCore.Mvc;
//using Persons.API.Dtos.Common;
//using SistemaDeReservas.API.Dtos.Reservas;
//using SistemaDeReservas.API.Services;
//using SistemaDeReservas.API.Services.Interfaces;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace SistemaDeReservas.API.Controllers
//{
//    [Route("api/Reserva")]
//    [ApiController]
//    public class ReservaController : ControllerBase
//    {
//        private readonly IReservaService _reservaService;

//        public ReservaController(IReservaService reservaService)
//        {
//            _reservaService = reservaService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<ResponseDto<List<ReservaDto>>>> GetAll()
//        {
//            var response = await _reservaService.GetAllAsync();
//            return StatusCode(response.StatusCode, response);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<ResponseDto<ReservaDto>>> GetById(int id)
//        {
//            var response = await _reservaService.GetByIdAsync(id);
//            return StatusCode(response.StatusCode, response);
//        }

//        [HttpPost]
//        public async Task<ActionResult<ResponseDto<ReservaActionResponseDto>>> Create([FromBody] ReservaCreateDto dto)
//        {
//            var response = await _reservaService.CreateAsync(dto);
//            return StatusCode(response.StatusCode, response);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<ResponseDto<ReservaActionResponseDto>>> Edit(int id, [FromBody] ReservaEditDto dto)
//        {
//            var response = await _reservaService.EditAsync(id, dto);
//            return StatusCode(response.StatusCode, response);
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ResponseDto<bool>>> Delete(int id)
//        {
//            var response = await _reservaService.DeleteAsync(id);
//            return StatusCode(response.StatusCode, response);
//        }
//    }
//}