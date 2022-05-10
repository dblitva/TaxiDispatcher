using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Responses;

namespace TaxiDispatcher.Application.Queries.Taxi
{
    public  class GetAllTaxisQuery : IRequest<List<TaxiResponse>>
    {
    }
}
