using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Queries.Taxi;
using TaxiDispatcher.Application.Responses;
using TaxiDispatcher.Repository.Abstraction;

namespace TaxiDispatcher.Application.Handlers.Taxi
{
    public class GetTaxiByIdQueryHandler : IRequestHandler<GetTaxiByIdQuery, TaxiResponse>
    {
        private readonly IMapper _mapper;
        public readonly ITaxiRepository _taxiRepository;
        public GetTaxiByIdQueryHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }
        public async Task<TaxiResponse> Handle(GetTaxiByIdQuery request, CancellationToken cancellationToken)
        {
            var taxi = _taxiRepository.GetById(request.Id);
            var taxisResponse = _mapper.Map<TaxiResponse>(taxi);
            return taxisResponse;
        }
    }
}
