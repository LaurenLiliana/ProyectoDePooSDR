using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Pagos;

namespace SistemaDeReservas.API.Services.Interfaces
{
    public interface IPagoService
    {
        Task<ResponseDto<PagoDto>> GetByIdAsync(int id);
        Task<ResponseDto<List<PagoDto>>> GetAllAsync();
        Task<ResponseDto<PagoActionResponseDto>> CreateAsync(PagoCreateDto dto);
        Task<ResponseDto<PagoActionResponseDto>> EditAsync(int id, PagoEditDto dto);
        Task<ResponseDto<bool>> DeleteAsync(int id);
    }
}

