using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;
using TaxiDispatcher.Client.RestComunication;
using TaxiDispatcher.Common;

namespace TaxiDispatcher.Client
{
    public class TaxiDispatcherClient
    {
        public async Task Run(IServiceProvider services)
        {
            var restService = ActivatorUtilities.GetServiceOrCreateInstance<RestService>(services);


            var orderRideRequest1 = new OrderRideRequest
            {
                LocationFrom = 5,
                LocationTo = 0,
                RideType = Constants.RideTypes.City,
                Time = new DateTime(2022, 1, 1, 23, 0, 0)
            };
            var orderResponse1 = await restService.OrderRide(orderRideRequest1);
            var ride1 = await restService.AcceptRide(new AcceptRideRequest { RideId = orderResponse1.Id });

            var orderRideRequest2 = new OrderRideRequest
            {
                LocationFrom = 0,
                LocationTo = 12,
                RideType = Constants.RideTypes.InterCity,
                Time = new DateTime(2022, 1, 1, 9, 0, 0)
            };
            var orderResponse2 = await restService.OrderRide(orderRideRequest2);
            var ride2 = await restService.AcceptRide(new AcceptRideRequest { RideId = orderResponse2.Id });

            var orderRideRequest3 = new OrderRideRequest
            {
                LocationFrom = 5,
                LocationTo = 0,
                RideType = Constants.RideTypes.City,
                Time = new DateTime(2022, 1, 1, 11, 0, 0)
            };
            var orderResponse3 = await restService.OrderRide(orderRideRequest3);
            var ride3 = await restService.AcceptRide(new AcceptRideRequest { RideId = orderResponse3.Id });

            var orderRideRequest4 = new OrderRideRequest
            {
                LocationFrom = 35,
                LocationTo = 12,
                RideType = Constants.RideTypes.City,
                Time = new DateTime(2022, 1, 1, 11, 0, 0)
            };
            var orderResponse4 = await restService.OrderRide(orderRideRequest4);
            var ride4 = await restService.AcceptRide(new AcceptRideRequest { RideId = orderResponse4.Id });

        }
    }
}
