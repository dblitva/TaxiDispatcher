using MediatR;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Commands.Ride
{
    public class AcceptRideCommand : IRequest<AcceptRideResponse>
    {
        public string RideId { get; set; }
    }
}
