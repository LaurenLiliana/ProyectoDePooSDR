using AutoMapper;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Dtos.Clientes;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Hotel;
using SistemaDeReservas.API.Dtos.Pagos;
using SistemaDeReservas.API.Dtos.Reservas;
using SistemaDeReservas.API.Dtos.ServiciosAdicionales;

namespace SistemaDeReservas.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HotelEntity, HotelDto>();
            CreateMap<HotelEntity, Dtos.Hotel.HotelActionResponseDto>();
            CreateMap<HotelCreateDto, HotelEntity>();
            CreateMap<HotelEditDto, HotelEntity>();

           CreateMap<HabitacionEntity, HabitacionDto>();
            CreateMap<HabitacionEntity, Dtos.Habitacion.HabitacionActionResponseDto>();
            CreateMap<HabitacionCreateDto, HabitacionEntity>();
            CreateMap<HabitacionEditDto, HabitacionEntity>();

            CreateMap<ClienteEntity, ClienteDto>();
            CreateMap<ClienteEntity, Dtos.Cliente.ClienteActionResponseDto>();
            CreateMap<ClienteCreateDto, ClienteEntity>();
            CreateMap<ClienteEditDto, ClienteEntity>();

            CreateMap<ReservaEntity, ReservaDto>();
            CreateMap<ReservaEntity, Dtos.Reservas.ReservaActionResponseDto>();
            CreateMap<ReservaCreateDto, ReservaEntity>();
            CreateMap<ReservaEditDto, ReservaEntity>();

            CreateMap<PagoEntity, PagoDto>();
            CreateMap<PagoEntity, Dtos.Pagos.PagoActionResponseDto>();
            CreateMap<PagoCreateDto, PagoEntity>();
            CreateMap<PagoEditDto, PagoEntity>();

            CreateMap<ServicioAdicionalEntity, ServicioAdicionalDto>();
            CreateMap<ServicioAdicionalEntity, Dtos.ServiciosAdicionales.ServicioAdicionalActionResponseDto>();
            CreateMap<ServicioAdicionalCreateDto, ServicioAdicionalEntity>();
            CreateMap<ServicioAdicionalEditDto, ServicioAdicionalEntity>();
        }
    }
}