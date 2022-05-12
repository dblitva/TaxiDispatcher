using MediatR;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Common;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Ride
{
    public class AcceptRideCommandHandler : IRequestHandler<AcceptRideCommand, string>
    {
        private readonly IRideRepository _rideRepository;
        public AcceptRideCommandHandler(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }
        public async Task<string> Handle(AcceptRideCommand request, CancellationToken cancellationToken)
        {
            var ride = _rideRepository.GetById(request.RideId);
            ride.State = Constants.RideStates.Accepted;

            var taxi = ride.Taxi;
            taxi.Location = ride.LocationTo;

            return $"Ride accepted, waiting for driver: {taxi.Name}";
        }
    }
}
