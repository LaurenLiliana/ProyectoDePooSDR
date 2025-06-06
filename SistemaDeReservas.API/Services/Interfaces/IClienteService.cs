﻿using Persons.API.Dtos.Common;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Dtos.Clientes;

public interface IClienteService
{
    Task<ResponseDto<ClienteActionResponseDto>> GetByIdAsync(int id);
    Task<ResponseDto<List<ClienteActionResponseDto>>> GetAllAsync();
    Task<ResponseDto<ClienteActionResponseDto>> CreateAsync(ClienteCreateDto dto);
    Task<ResponseDto<ClienteActionResponseDto>> EditAsync(int id, ClienteEditDto dto);
    Task<ResponseDto<bool>> DeleteAsync(int id);
}