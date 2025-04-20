using AutoMapper;
using SistemaDeReservas.API.Database.Entities;
using SistemaDeReservas.API.Dtos.Cliente;
using SistemaDeReservas.API.Dtos.Clientes;
using SistemaDeReservas.API.Dtos.Habitacion;
using SistemaDeReservas.API.Dtos.Habitaciones;
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
            CreateMap<HotelEntity, HotelActionResponseDto>()
                 .ForMember(dest => dest.Habitaciones, opt => opt.MapFrom(src => src.Habitaciones));
            CreateMap<HotelCreateDto, HotelEntity>();
            CreateMap<HotelEditDto, HotelEntity>();
            CreateMap<HotelEntity, HotelParaHabitacionDto>();

            CreateMap<HabitacionEntity, HabitacionDto>();
            CreateMap<HabitacionEntity, HabitacionActionResponseDto>();
            CreateMap<HabitacionCreateDto, HabitacionEntity>();
            CreateMap<HabitacionEditDto, HabitacionEntity>();
            CreateMap<HabitacionEntity, HabitacionActionResponseDto>();
            CreateMap<HabitacionEntity, HabitacionActionResponseDtoDos>()
              .ForMember(dest => dest.Hotel, opt => opt.MapFrom(src => src.Hotel));


            CreateMap<ClienteEntity, ClienteDto>();
            CreateMap<ClienteEntity, Dtos.Cliente.ClienteActionResponseDto>();
            CreateMap<ClienteCreateDto, ClienteEntity>();
            CreateMap<ClienteEditDto, ClienteEntity>();

            CreateMap<ReservaEntity, ReservaDto>()
            .ForMember(dest => dest.Habitacion, opt => opt.MapFrom((src, dest, member, context) =>
                new List<HabitacionActionResponseDto> { context.Mapper.Map<HabitacionActionResponseDto>(src.Habitacion) }));
            CreateMap<ReservaEntity, Dtos.Reservas.ReservaActionResponseDto>();
            CreateMap<ReservaCreateDto, ReservaEntity>();
            CreateMap<ReservaEditDto, ReservaEntity>();


            CreateMap<PagoEntity, PagoDto>();
            CreateMap<PagoEntity, Dtos.Pagos.PagoActionResponseDto>();
            CreateMap<PagoCreateDto, PagoEntity>();
            CreateMap<PagoCreateDto, PagoEntity>();
            CreateMap<PagoEditDto, PagoEntity>();

            CreateMap<ServicioAdicionalEntity, ServicioAdicionalDto>();
            CreateMap<ServicioAdicionalEntity, Dtos.ServiciosAdicionales.ServicioAdicionalActionResponseDto>();
            CreateMap<ServicioAdicionalCreateDto, ServicioAdicionalEntity>();
            CreateMap<ServicioAdicionalEditDto, ServicioAdicionalEntity>();
        }
    }
}