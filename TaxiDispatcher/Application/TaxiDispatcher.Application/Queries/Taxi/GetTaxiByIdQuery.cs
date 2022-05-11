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
        public string Id { get; set; }
        public int? Pera { get; set; }
    }

    public class GetTaxiByIdQueryValidator : AbstractValidator<GetTaxiByIdQuery>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().MaximumLength(5).WithMessage("Maksimalan dozvoljen broj karaktera je 5!");
            RuleFor(x => x.Pera).NotNull().LessThan(5).WithMessage("JBG");
        }
    }
}
