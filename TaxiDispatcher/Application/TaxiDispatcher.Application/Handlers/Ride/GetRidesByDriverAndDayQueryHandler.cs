using MediatR;
using TaxiDispatcher.Application.Queries.Ride;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Handlers.Ride
{
    public class GetRidesByDriverAndDayQueryHandler : IRequestHandler<GetRidesByDriverAndDayQuery, List<RidesByDriverResponse>>
    {
        public async Task<List<RidesByDriverResponse>> Handle(GetRidesByDriverAndDayQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
