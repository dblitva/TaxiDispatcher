using TaxiDispatcher.Client.Model.Request;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Integration
{
    public class IntegrationTests : BaseTestsSetup
    {
        public static readonly object[][] CorrectData =
        {
            new object[] { -5, 0, 0,  new DateTime(2022, 1, 1, 23, 0, 0), true, false },
            new object[] { 5, 0, 0,  new DateTime(2022, 1, 1, 23, 0, 0), false, true },
            new object[] { 0, 12, 0, new DateTime(2022, 1, 1, 9, 0, 0), false, true },
            new object[] { 5, 0, 1, new DateTime(2022, 1, 1, 11, 0, 0), false, true },
            new object[] { 35, 12, 0, new DateTime(2022, 1, 1, 11, 0, 0), false, false }
        };

        [Theory, MemberData(nameof(CorrectData))]
        public async Task OrderRideAndAcceptTest(int locationFrom, int locationTo, int rideType, DateTime time, bool badResponse, bool ordered)
        {
            // Arrange

            // Act
            var orderRideRequest = new OrderRideRequest { LocationFrom = locationFrom, LocationTo = locationTo, RideType = rideType, Time = time };
            var orderResponse = await OrderRide(orderRideRequest);
            if (!badResponse && ordered)
            {
                await AcceptRide(new AcceptRideRequest { RideId = orderResponse.Response.Ride.Id });
            }

            // Assert
            if (badResponse)
            {
                Assert.Equal(orderResponse.ValidationResponse.status, 400);
            }
            else if(ordered)
            {
                Assert.Equal(orderResponse.Response.RideOrdered, ordered);
            }
            else
            {
                Assert.Equal(orderResponse.Response.OrderCancelationReason, Common.Constants.Messages.TaxiNotAvailable);
            }
        }
    }
}
