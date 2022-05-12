using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Queries.Taxi;
using TaxiDispatcher.Application.Responses.Taxi;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Taxi
{
    public class GetTaxiByIdQueryHandler : IRequestHandler<GetTaxiByIdQuery, TaxiResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaxiRepository _taxiRepository;
        private readonly ILogger<GetTaxiByIdQueryHandler> _logger;
        public GetTaxiByIdQueryHandler(ITaxiRepository taxiRepository, IMapper mapper, ILogger<GetTaxiByIdQueryHandler> logger)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<TaxiResponse> Handle(GetTaxiByIdQuery request, CancellationToken cancellationToken)
        {
            var taxi = _taxiRepository.GetById(request.Id);
            var taxisResponse = _mapper.Map<TaxiResponse>(taxi);
            _logger.LogWarning("Logger test!!!");
            return taxisResponse;
        }
    }
}
