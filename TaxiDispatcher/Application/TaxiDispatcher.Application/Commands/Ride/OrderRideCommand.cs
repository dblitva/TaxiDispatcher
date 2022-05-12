using FluentValidation;
using MediatR;
using TaxiDispatcher.Application.Responses.Ride;

namespace TaxiDispatcher.Application.Commands.Ride
{
    public class OrderRideCommand : IRequest<RideResponse>
    {
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public int RideType { get; set; }
        public DateTime Time { get; set; }
    }

    public class OrderRideCommandValidator : AbstractValidator<OrderRideCommand>
    {
        public OrderRideCommandValidator()
        {
            RuleFor(x => x.LocationFrom).NotNull().GreaterThan(0);
            RuleFor(x => x.LocationTo).NotNull().GreaterThan(0);
            RuleFor(x => x.RideType).NotNull().GreaterThan(0);
           // RuleFor(x => x.Time).NotNull().GreaterThan(DateTime.Now);
        }
    }
}
