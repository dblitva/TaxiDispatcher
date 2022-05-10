using MediatR;
using TaxiDispatcher.Application.Responses;

namespace TaxiDispatcher.Application.Commands
{
    public class OrderRideCommand : IRequest<RideResponse>
    {
    }
}
