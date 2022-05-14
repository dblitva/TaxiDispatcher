using AutoMapper;
using TaxiDispatcher.Application.Mappers.Ride;

namespace TaxiDispatcher.Tests.Unit.Application
{
    public class BaseTestsSetup
    {
        protected IMapper _mapper;

        public BaseTestsSetup()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new RideMappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
    }
}
