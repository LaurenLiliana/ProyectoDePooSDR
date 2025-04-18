using Microsoft.AspNetCore.Mvc;
using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Hotel;
using SistemaDeReservas.API.Services.Interfaces;
using System.Threading.Tasks;

namespace SistemaDeReservas.API.Controllers
{
    [Route("api/hoteles")]
    [ApiController]
    public class HotelesController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelesController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        // GET: api/hoteles
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<HotelDto>>>> GetAll()
        {
            var response = await _hotelService.GetListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // GET: api/hoteles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<HotelDto>>> GetById(int id)
        {
            var response = await _hotelService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST: api/hoteles
        [HttpPost]
        public async Task<ActionResult<ResponseDto<HotelActionResponseDto>>> Create([FromBody] HotelCreateDto dto)
        {
            var response = await _hotelService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // PUT: api/hoteles/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<HotelActionResponseDto>>> Update(
            int id,
            [FromBody] HotelEditDto dto)
        {
            var response = await _hotelService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE: api/hoteles/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(int id)
        {
            var response = await _hotelService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}