using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Queries.Ride
{
    public class GetRidesByDriverAndDayQuery : IRequest<List<RidesByDriverResponse>>
    {
    }
}
