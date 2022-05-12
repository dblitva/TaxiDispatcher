using MediatR;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Responses.Ride;
using TaxiDispatcher.Common;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Ride
{
    public class OrderRideCommandHandler : IRequestHandler<OrderRideCommand, RideResponse>
    {
        public readonly ITaxiRepository _taxiRepository;
        public OrderRideCommandHandler(ITaxiRepository taxiRepository)
        {
            _taxiRepository = taxiRepository;
        }
        public async Task<RideResponse> Handle(OrderRideCommand request, CancellationToken cancellationToken)
        {
            var bestTaxi = await FindBestTaxi(request);
            var price = await CalculatePraice(request, bestTaxi);

            var rideResponse = new RideResponse
            {
                Id = Guid.NewGuid().ToString(),
                LocationFrom = request.LocationFrom,
                LocationTo = request.LocationTo,
                TaxiDriverId = bestTaxi.Id,
                TaxiDriverName = bestTaxi.Name,
                Price = price
            };

            return rideResponse;
        }

        private async Task<Repository.Model.Taxi> FindBestTaxi(OrderRideCommand request)
        {
            var taxis = _taxiRepository.GetAll();
            var orderdTaxisByLocation = taxis.OrderBy(x => Math.Abs(x.Location)).ToList();

            var taxi1 = orderdTaxisByLocation.LastOrDefault(x => x.Location < request.LocationFrom);
            var taxi2 = orderdTaxisByLocation.FirstOrDefault(x => x.Location > request.LocationFrom);

            if (taxi1 == null)
            {
                return taxi2;
            }
            else if (taxi2 == null)
            {
                return taxi1;
            }
            else
            {
                return Math.Abs(request.LocationFrom - taxi1.Location) < Math.Abs(request.LocationFrom - taxi2.Location) ? taxi1 : taxi2;
            }
        }

        private async Task<int> CalculatePraice(OrderRideCommand request, Repository.Model.Taxi taxi)
        {
            var price = taxi.Company.Rate * Math.Abs(request.LocationFrom - request.LocationTo);

            if (request.RideType == Constants.InterCity)
            {
                price *= 2;
            }

            return price;
        }
    }
}
