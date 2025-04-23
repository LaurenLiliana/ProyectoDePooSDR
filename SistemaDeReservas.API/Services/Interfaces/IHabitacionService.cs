using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Habitaciones;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IHabitacionService
    {
        Task<ResponseDto<List<HabitacionActionResponseDtoDos>>> GetListAsync();
        Task<ResponseDto<HabitacionActionResponseDtoDos>> GetByIdAsync(int id);
        Task<ResponseDto<HabitacionActionResponseDto>> CreateAsync(HabitacionCreateDto dto);
        Task<ResponseDto<HabitacionActionResponseDto>> EditAsync(int id, HabitacionEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);

        // S A M A
        Task<List<HabitacionEntity>> BuscarHabitacionesAsync(BuscarHabitacionesDto filtros, int pagina = 1, int tamaño = 10);
    }
}