using MediatR;
using TaxiDispatcher.Application.Commands;
using TaxiDispatcher.Application.Responses;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers
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
            throw new NotImplementedException();
        }
    }
}
