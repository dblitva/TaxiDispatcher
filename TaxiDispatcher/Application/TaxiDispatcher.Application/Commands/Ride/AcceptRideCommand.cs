using MediatR;

namespace TaxiDispatcher.Application.Commands.Ride
{
    public class AcceptRideCommand : IRequest<string>
    {
        public string RideId { get; set; }
    }
}
