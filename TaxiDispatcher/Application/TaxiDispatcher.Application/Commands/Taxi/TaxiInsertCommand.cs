using FluentValidation;
using MediatR;

namespace TaxiDispatcher.Application.Commands.Taxi
{
    public class TaxiInsertCommand : IRequest<string>
    {
        public string Name { get; set; }
    }

    public class GetTaxiByIdQueryValidator : AbstractValidator<TaxiInsertCommand>
    {
        public GetTaxiByIdQueryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is empty!");
        }
    }
}
