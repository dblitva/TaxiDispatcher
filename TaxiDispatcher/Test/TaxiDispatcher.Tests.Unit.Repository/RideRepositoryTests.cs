using Autofac.Extras.Moq;
using TaxiDispatcher.Common;
using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.InMemoryDatabase;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Repository
{
    public class RideRepositoryTests
    {
        [Fact]
        public void TaxiRepository_GetById()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Taxi taxi = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 50 };
                Ride ride = new Ride
                {
                    Id = Guid.NewGuid().ToString(),
                    LocationFrom = 0,
                    LocationTo = 5,
                    Taxi = taxi,
                    Price = 50,
                    Time = DateTime.Now,
                    State = Constants.RideStates.Ordered
                };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;
                context.Taxis.Add(taxi);
                context.Rides.Add(ride);

                var rideRepository = mock.Create<RideRepository>();

                //Act
                var actual = rideRepository.GetById(ride.Id);

                //Assert
                Assert.Equal(context.Rides.First().Id, actual.Id);

            }
        }

        [Fact]
        public void TaxiRepository_GetAcceptedRidesByDay()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Taxi taxi = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 50 };

                Ride ride = new Ride { Id = Guid.NewGuid().ToString(), LocationFrom = 0, LocationTo = 5, Taxi = taxi, Price = 50, Time = DateTime.Now, State = Constants.RideStates.Accepted };
                Ride ride1 = new Ride { Id = Guid.NewGuid().ToString(), LocationFrom = 50, LocationTo = 100, Taxi = taxi, Price = 500, Time = DateTime.Now, State = Constants.RideStates.Accepted };
                Ride ride2 = new Ride { Id = Guid.NewGuid().ToString(), LocationFrom = 25, LocationTo = 5, Taxi = taxi, Price = 300, Time = new DateTime(2022, 1, 1), State = Constants.RideStates.Accepted };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;
                context.Taxis.Add(taxi);
                context.Rides.Add(ride);
                context.Rides.Add(ride1);
                context.Rides.Add(ride2);

                var rideRepository = mock.Create<RideRepository>();

                //Act
                var actuals = rideRepository.GetAcceptedRidesByDay(ride.Time);

                //Assert
                Assert.All(actuals, x => Assert.Equal(x.Time.Date, ride.Time.Date));
            }
        }

        [Fact]
        public void RideRepository_Insert()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Taxi taxi = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 50 };
                Ride ride = new Ride
                {
                    LocationFrom = 0,
                    LocationTo = 5,
                    Taxi = taxi,
                    Price = 50,
                    Time = DateTime.Now,
                    State = Constants.RideStates.Ordered
                };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;

                var rideRepository = mock.Create<RideRepository>();

                //Act
                rideRepository.Insert(ride);

                //Assert
                Assert.Single(context.Rides);

            }
        }
    }
}
