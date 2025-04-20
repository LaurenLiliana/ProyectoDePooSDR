using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Dtos.Reservas;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IReservaService
    {
        Task<ResponseDto<ReservaActionResponseDto>> GetByIdAsync(int id);
        Task<ResponseDto<List<ReservaActionResponseDto>>> GetListAsync();
        Task<ResponseDto<ReservaActionResponseDto>> CreateAsync(ReservaCreateDto dto);
        Task<ResponseDto<ReservaActionResponseDto>> EditAsync(int id, ReservaEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
    }
}