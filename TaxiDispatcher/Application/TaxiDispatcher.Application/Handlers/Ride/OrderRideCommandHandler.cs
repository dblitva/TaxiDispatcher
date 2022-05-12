using MediatR;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Responses.Ride;
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
            var taxis = _taxiRepository.GetAll();
            var orderdTaxisByLocation = taxis.OrderBy(x => Math.Abs(x.Location)).ToList();

            var taxi1 = orderdTaxisByLocation.Last(x=>x.Location < request.LocationFrom);
            var taxi2 = orderdTaxisByLocation.First(x=>x.Location > request.LocationFrom);

            var bestTaxi = Math.Abs(request.LocationFrom - taxi1.Location) < Math.Abs(request.LocationFrom - taxi2.Location) ? taxi1 : taxi2;

            return null;
        }
    }
}
