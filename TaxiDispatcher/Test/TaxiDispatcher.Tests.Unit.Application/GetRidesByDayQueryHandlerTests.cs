using Autofac.Extras.Moq;
using Moq;
using TaxiDispatcher.Application.Handlers.Ride;
using TaxiDispatcher.Application.Queries.Ride;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Application
{
    public class GetRidesByDayQueryHandlerTests : BaseTestsSetup
    {
        [Fact]
        public async Task GetRidesByDay()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var taxiId = Guid.NewGuid().ToString();
                var rideRepository = mock.Mock<IRideRepository>();
                rideRepository.Setup(x => x.GetAcceptedRidesByDay(It.IsAny<DateTime>()))
                              .Returns(new List<Ride>
                              {
                                  new Ride {Id = Guid.NewGuid().ToString(), LocationFrom = 10, LocationTo = 20, Price = 250, State = 1, Time = new DateTime(2022, 1, 1),
                                            Taxi = new Taxi { Id = taxiId, Name = "Nenad", Location = 21,  Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } } },
                                  new Ride {Id = Guid.NewGuid().ToString(), LocationFrom = 3, LocationTo = 34, Price = 560, State = 1, Time = new DateTime(2022, 1, 1),
                                            Taxi = new Taxi { Id = taxiId, Name = "Nenad", Location = 21,  Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } } },
                                  new Ride {Id = Guid.NewGuid().ToString(), LocationFrom = 6, LocationTo = 56, Price = 458, State = 1, Time = new DateTime(2022, 1, 1),
                                            Taxi = new Taxi { Id = taxiId, Name = "Nenad", Location = 21,  Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } } },
                              });

                var handler = new GetRidesByDayQueryHandler(_mapper, rideRepository.Object);

                //Act
                var actual = await handler.Handle(new GetRidesByDayQuery { Date = It.IsAny<DateTime>() }, new CancellationToken());

                //Assert
                Assert.Equal(actual.Count(), 1);
                foreach (var driver in actual)
                {
                    Assert.Equal(driver.Rides.Count(), 3);
                }
            }
        }
    }
}
