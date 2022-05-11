using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaxiDispatcher.Application.Handlers;
using TaxiDispatcher.Application.Mappers.Taxi;
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
            services.AddScoped<ITaxiRepository, TaxiRepository>();

            //AutoMapper
            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaxiMappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

           
        }
    }
}
