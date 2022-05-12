using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TaxiDispatcher.Application.Commands.Taxi;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Taxi
{
    public class TaxiInsertCommandHandler : IRequestHandler<TaxiInsertCommand, string>
    {
        private readonly IMapper _mapper;
        public readonly ITaxiRepository _taxiRepository;
        public readonly ILogger<TaxiInsertCommandHandler> _logger;
        public TaxiInsertCommandHandler(ITaxiRepository taxiRepository, IMapper mapper, ILogger<TaxiInsertCommandHandler> logger)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<string> Handle(TaxiInsertCommand request, CancellationToken cancellationToken)
        {
            var taxi = new Repository.Model.Taxi { Id = Guid.NewGuid().ToString(), Name = request.Name, Location = request.Location };
            return _taxiRepository.Insert(taxi);            
        }
    }
}
