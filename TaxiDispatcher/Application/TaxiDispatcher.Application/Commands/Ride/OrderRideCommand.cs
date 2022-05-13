using FluentValidation;
using MediatR;
using TaxiDispatcher.Application.Responses.Ride;
using TaxiDispatcher.Common;

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
        private readonly List<int> rideTypes = new List<int>() { 0, 1 };
        public OrderRideCommandValidator()
        {
            RuleFor(x => x.LocationFrom).NotNull().GreaterThanOrEqualTo(0).WithMessage(Constants.Messages.Validation.LocationFrom);
            RuleFor(x => x.LocationTo).NotNull().GreaterThanOrEqualTo(0).WithMessage(Constants.Messages.Validation.LocationTo);
            RuleFor(x => x.RideType).NotNull().Must(y => rideTypes.Contains(y)).WithMessage(Constants.Messages.Validation.RideType);
        }
    }
}
