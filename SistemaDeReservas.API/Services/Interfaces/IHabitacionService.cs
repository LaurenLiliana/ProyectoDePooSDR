using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Habitacion;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IHabitacionService
    {
        Task<ResponseDto<List<HabitacionDto>>> GetListAsync();
        Task<ResponseDto<HabitacionDto>> GetByIdAsync(int id);
        Task<ResponseDto<HabitacionActionResponseDto>> CreateAsync(HabitacionCreateDto dto);
        Task<ResponseDto<HabitacionActionResponseDto>> EditAsync(int id, HabitacionEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
    }
}