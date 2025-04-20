using SistemaDeReservas.API.Dtos.ServiciosAdicionales;
using Persons.API.Dtos.Common;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IServicioAdicionalService
    {
        Task<ResponseDto<ServicioAdicionalDto>> GetByIdAsync(int id);
        Task<ResponseDto<List<ServicioAdicionalDto>>> GetAllAsync();
        Task<ResponseDto<ServicioAdicionalActionResponseDto>> CreateAsync(ServicioAdicionalCreateDto dto);
        Task<ResponseDto<ServicioAdicionalActionResponseDto>> EditAsync(int id, ServicioAdicionalEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
    }
}