using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Responses.Taxi;

namespace TaxiDispatcher.Application.Mappers.Taxi
{
    public class TaxiMappingProfile : Profile
    {
        public TaxiMappingProfile()
        {
            CreateMap<Repository.Model.Taxi, TaxiResponse>().ReverseMap();
        }
    }
}
