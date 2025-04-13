using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Hotel;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IHotelService
    {
        Task<ResponseDto<HotelDto>> GetByIdAsync(int id);
        Task<ResponseDto<List<HotelDto>>> GetListAsync();
        Task<ResponseDto<HotelActionResponseDto>> CreateAsync(HotelCreateDto dto);
        Task<ResponseDto<HotelActionResponseDto>> EditAsync(int id, HotelEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
        
    }
}