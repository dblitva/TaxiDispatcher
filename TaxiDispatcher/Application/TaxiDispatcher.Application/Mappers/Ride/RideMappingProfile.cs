using AutoMapper;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Mappers.Ride
{
    public class RideMappingProfile : Profile
    {
        public RideMappingProfile()
        {
            CreateMap<Repository.Model.Ride, RideResponse>()
                .ForMember(x=>x.TaxiDriverId, opt => opt.MapFrom(src => src.Taxi.Id))
                .ForMember(x=>x.TaxiDriverName, opt => opt.MapFrom(src => src.Taxi.Name));
        }
    }
}
