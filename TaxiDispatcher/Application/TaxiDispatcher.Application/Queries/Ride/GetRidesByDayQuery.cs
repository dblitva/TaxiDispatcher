using MediatR;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Queries.Ride
{
    public class GetRidesByDayQuery : IRequest<List<RidesByDriverResponse>>
    {
        public DateTime Date { get; set; }
    }
}
