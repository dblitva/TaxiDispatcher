using AutoMapper;
using MediatR;
using TaxiDispatcher.Application.Queries.Ride;
using TaxiDispatcher.Application.Responses.Ride;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Ride
{
    public class GetRidesByDayQueryHandler : IRequestHandler<GetRidesByDayQuery, List<RidesByDriverResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IRideRepository _rideRepository;
        public GetRidesByDayQueryHandler(IMapper mapper, IRideRepository rideRepository)
        {
            _mapper = mapper;
            _rideRepository = rideRepository;
        }
        public async Task<List<RidesByDriverResponse>> Handle(GetRidesByDayQuery request, CancellationToken cancellationToken)
        {
            var rides = _rideRepository.GetRidesByDay(request.Date);

            var ridesByDriverResponse = rides.GroupBy(
                p => p.Taxi.Id,
                (key, g) => new RidesByDriverResponse { DriverId = key, DriverName = g.FirstOrDefault().Taxi.Name, Total = g.Sum(s=>s.Price), Rides = _mapper.Map<List<Responses.Ride.Ride>>(g.ToList()) })
                .ToList();

            return ridesByDriverResponse;
        }
    }
}
