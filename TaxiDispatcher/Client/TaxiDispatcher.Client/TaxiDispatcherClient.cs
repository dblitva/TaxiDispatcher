using Microsoft.Extensions.DependencyInjection;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;
using TaxiDispatcher.Client.RestComunication;
using TaxiDispatcher.Common;

namespace TaxiDispatcher.Client
{
    public class TaxiDispatcherClient
    {
        private RestService _restService;
        public async Task Run(IServiceProvider services)
        {
            _restService = ActivatorUtilities.GetServiceOrCreateInstance<RestService>(services);

            await RideProcessing(5, 0, Constants.RideTypes.City, new DateTime(2022, 1, 1, 23, 0, 0));

            Console.WriteLine(Environment.NewLine);           
            await RideProcessing(0, 12, Constants.RideTypes.City, new DateTime(2022, 1, 1, 9, 0, 0));

            Console.WriteLine(Environment.NewLine);           
            await RideProcessing(5, 0, Constants.RideTypes.City, new DateTime(2022, 1, 1, 11, 0, 0));

            Console.WriteLine(Environment.NewLine);            
            await RideProcessing(35, 12, Constants.RideTypes.City, new DateTime(2022, 1, 1, 11, 0, 0));

            Console.WriteLine(Environment.NewLine);
            await GetRideList();

            Console.ReadLine();
        }

        private async Task RideProcessing(int locationFrom, int locationTo, int rideType, DateTime time)
        {
            Console.WriteLine($"Ordering ride from {locationFrom} to {locationTo}...");
            var orderResponse = await OrderRide(locationFrom, locationTo, rideType, time);
            if (!orderResponse.IsBadResponse)
            {
                if (orderResponse.Response.RideOrdered)
                {
                    Console.WriteLine("Ride ordered, price: " + orderResponse.Response.Ride.Price.ToString());
                    var ride = await _restService.AcceptRide(new AcceptRideRequest { RideId = orderResponse.Response.Ride.Id });
                    Console.WriteLine(ride.Response);
                }
                else
                {
                    Console.WriteLine(orderResponse.Response.OrderCancelationReason);
                }
            }
            else
            {
                Console.WriteLine(orderResponse.ValidationResponse.ErrorsToString());
            }
        }
        public async Task<ResponseWrapper<OrderRideResponse>> OrderRide(int locationFrom, int locationTo, int rideType, DateTime time) 
        {
            var orderRideRequest = new OrderRideRequest
            {
                LocationFrom = locationFrom,
                LocationTo = locationTo,
                RideType = rideType,
                Time = time
            };
            
            return await _restService.OrderRide(orderRideRequest);
        }

        public async Task GetRideList()
        {
            var drivers = await _restService.GetRidesByDate(new DateTime(2022, 01, 01));
            if(!drivers.IsBadResponse) 
            {
                foreach (var driver in drivers.Response)
                {
                    Console.WriteLine($"Driver {driver.DriverName} earned today:");
                    foreach(var ride in driver.Rides)
                    {
                        Console.WriteLine($"Price: {ride.Price}");
                    }
                    Console.WriteLine($"Total: {driver.Total}");
                    Console.WriteLine(Environment.NewLine);
                }
            }
            else
            {
                Console.WriteLine(drivers.ValidationResponse.ErrorsToString());
            }
        }
    }
}
