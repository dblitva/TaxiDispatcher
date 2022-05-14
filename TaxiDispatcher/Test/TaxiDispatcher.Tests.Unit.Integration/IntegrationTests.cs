using TaxiDispatcher.Client.Model.Request;
using Xunit;

namespace TaxiDispatcher.Tests.Integration
{
    public class IntegrationTests : BaseTestsSetup
    {
        public static readonly object[][] OrderRideData =
        {
            new object[] { -5, 0, 0,  new DateTime(2022, 1, 1, 23, 0, 0), true, false },
            new object[] { 5, 0, 0,  new DateTime(2022, 1, 1, 23, 0, 0), false, true },
            new object[] { 0, 12, 0, new DateTime(2022, 1, 1, 9, 0, 0), false, true },
            new object[] { 5, 0, 1, new DateTime(2022, 1, 1, 11, 0, 0), false, true },
            new object[] { 35, 12, 0, new DateTime(2022, 1, 1, 11, 0, 0), false, false },
            new object[] { 0, 12, 0, new DateTime(2022, 1, 2, 9, 0, 0), false, true },
            new object[] { 5, 0, 1, new DateTime(2022, 1, 2, 11, 0, 0), false, true },
            new object[] { 35, 12, 0, new DateTime(2022, 1, 2, 11, 0, 0), false, false }
        };

        public static readonly object[][] GetRideListData =
        {
            new object[] { new DateTime(2022, 1, 1), 1, 3 },
            new object[] { new DateTime(2022, 1, 2), 1, 2 },
            new object[] { new DateTime(2022, 1, 3), 0, 0 }
        };

        [Theory, MemberData(nameof(OrderRideData))]
        public async Task OrderRideTest(int locationFrom, int locationTo, int rideType, DateTime time, bool badResponse, bool ordered)
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
            else if (ordered)
            {
                Assert.Equal(orderResponse.Response.RideOrdered, ordered);
            }
            else
            {
                Assert.Equal(orderResponse.Response.OrderCancelationReason, Common.Constants.Messages.TaxiNotAvailable);
            }
        }

        [Theory, MemberData(nameof(GetRideListData))]
        public async Task GetRideListTest(DateTime forDate, int driverCount, int rideCount)
        {
            // Arrange

            // Act
            foreach (var data in OrderRideData)
            {
                var orderRideRequest = new OrderRideRequest { LocationFrom = (int)data[0], LocationTo = (int)data[1], RideType = (int)data[2], Time = (DateTime)data[3] };
                var orderResponse = await OrderRide(orderRideRequest);
                if (!orderResponse.IsBadResponse && orderResponse.Response.RideOrdered)
                {
                    await AcceptRide(new AcceptRideRequest { RideId = orderResponse.Response.Ride.Id });
                }
            }
            var drivers = await GetRidesByDate(forDate);

            Assert.Equal(drivers.Response.Count(), driverCount);
            foreach (var driver in drivers.Response)
            {
                Assert.Equal(driver.Rides.Count(), rideCount);
            }
        }
    }
}
