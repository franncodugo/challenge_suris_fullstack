using AutoMapper;
using Reservation_Suris.Application.DTOs;
using Reservation_Suris.Domain.Models;

namespace Reservation_Suris.Application.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Service, ServiceDto>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<Client, ClientDto>();
        CreateMap<ReservationDto, Reservation>();
    }
}
