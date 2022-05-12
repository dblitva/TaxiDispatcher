using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaxiDispatcher.Application.Handlers.Ride;
using TaxiDispatcher.Application.Mappers.Ride;
using TaxiDispatcher.Application.Mappers.Taxi;
using TaxiDispatcher.DataInitialization;
using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.InMemoryDatabase;

namespace TaxiDispatcher.WebApi.Initialization
{
    public static class InitializationComponents
    {
        public static void Initialize(this IServiceCollection services, IConfiguration configuration)
        {
            //Database
            services.AddSingleton<InMemoryDatabaseContext>();
            
            // MediatR
            services.AddMediatR(typeof(OrderRideCommandHandler).GetTypeInfo().Assembly);

            //Repositories
            services.AddSingleton<ITaxiRepository, TaxiRepository>();
            services.AddSingleton<ITaxiCompanyRepository, TaxiCompanyRepository>();
            services.AddSingleton<IRideRepository, RideRepository>();

            //AutoMapper
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaxiMappingProfile());
                mc.AddProfile(new RideMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddSingleton<IInitializationDatabase, InitializationDatabase>();
        }
    }
}
