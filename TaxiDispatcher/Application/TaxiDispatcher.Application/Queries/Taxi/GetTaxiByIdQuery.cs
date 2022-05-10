using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Application.Responses;

namespace TaxiDispatcher.Application.Queries.Taxi
{
    public class GetTaxiByIdQuery : IRequest<TaxiResponse>
    {
        public int Id { get; set; }
    }

    public class GetTaxiByIdQueryValidator : AbstractValidator<GetTaxiByIdQuery>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id mora biti veci od 0!");
        }
    }
}
