using MediatR;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Responses.Ride;
using TaxiDispatcher.Common;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Ride
{
    public class AcceptRideCommandHandler : IRequestHandler<AcceptRideCommand, AcceptRideResponse>
    {
        private readonly IRideRepository _rideRepository;
        public AcceptRideCommandHandler(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }
        public async Task<AcceptRideResponse> Handle(AcceptRideCommand request, CancellationToken cancellationToken)
        {
            var ride = _rideRepository.GetById(request.RideId);
            ride.State = Constants.RideStates.Accepted;

            var taxi = ride.Taxi;
            taxi.Location = ride.LocationTo;

            return new AcceptRideResponse { RideAccepted = true, Message = $"Ride accepted, waiting for driver: {taxi.Name}" };
        }
    }
}
