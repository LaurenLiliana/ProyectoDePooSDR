using Microsoft.AspNetCore.Mvc;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Habitaciones;
using SistemaDeReservas.API.Services.Interfaces;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/Habitaciones")]
    [ApiController]
    public class HabitacionesController : ControllerBase
    {
        private readonly IHabitacionService _habitacionService;

        public HabitacionesController(IHabitacionService habitacionService)
        {
            _habitacionService = habitacionService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<HabitacionActionResponseDtoDos>>>> GetAll()
        {
            var response = await _habitacionService.GetListAsync();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<HabitacionActionResponseDtoDos>>> GetById(int id)
        {
            var response = await _habitacionService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }



        [HttpPost]
        public async Task<ActionResult<ResponseDto<HabitacionActionResponseDto>>> Create(
            [FromBody] HabitacionCreateDto dto)
        {
            var response = await _habitacionService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<HabitacionActionResponseDto>>> Edit(
            int id,
            [FromBody] HabitacionEditDto dto)
        {
            var response = await _habitacionService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(int id)
        {
            var response = await _habitacionService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}