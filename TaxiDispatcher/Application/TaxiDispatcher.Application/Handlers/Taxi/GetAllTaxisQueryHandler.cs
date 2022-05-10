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
    public class GetAllTaxisQueryHandler : IRequestHandler<GetAllTaxisQuery, List<TaxiResponse>>
    {
        private readonly IMapper _mapper;
        public readonly ITaxiRepository _taxiRepository;
        public GetAllTaxisQueryHandler(ITaxiRepository taxiRepository, IMapper mapper)
        {
            _taxiRepository = taxiRepository;
            _mapper = mapper;
        }
        public async Task<List<TaxiResponse>> Handle(GetAllTaxisQuery request, CancellationToken cancellationToken)
        {
            var taxis = _taxiRepository.GetAll();
            var taxisResponse = _mapper.Map<List<TaxiResponse>>(taxis);
            return taxisResponse;
        }
    }
}
