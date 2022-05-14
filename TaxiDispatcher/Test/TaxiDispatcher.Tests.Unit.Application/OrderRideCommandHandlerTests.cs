using Autofac.Extras.Moq;
using Moq;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Handlers.Ride;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Application
{
    public class OrderRideCommandHandlerTests : BaseTestsSetup
    {
        private readonly List<Taxi> _taxiList = new List<Taxi>() {
                                  new Taxi { Id = Guid.NewGuid().ToString(), Name = "Nenad", Location = 21,  Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } },
                                  new Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 2, Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Naxi", Rate = 10 } },
                                  new Taxi { Id = Guid.NewGuid().ToString(), Name = "Goran", Location = 75, Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } },
                                  new Taxi { Id = Guid.NewGuid().ToString(), Name = "Milan", Location = 64, Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Naxi", Rate = 10 } }
                              };
        [Fact]
        public async Task OrderRide_HappyFlow()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var taxiRepository = mock.Mock<ITaxiRepository>();
                taxiRepository.Setup(x => x.GetAll())
                              .Returns(_taxiList);

                var rideRepository = mock.Mock<IRideRepository>();
                rideRepository.Setup(x => x.Insert(It.IsAny<Ride>()))
                              .Returns(Guid.NewGuid().ToString);

                var handler = new OrderRideCommandHandler(_mapper, taxiRepository.Object, rideRepository.Object);

                //Act
                var actual = await handler.Handle(new OrderRideCommand { LocationFrom = 15, LocationTo = 45, RideType = 0, Time = new DateTime(2022, 1, 1, 23, 0, 0) }, new CancellationToken ());

                //Assert
                Assert.Equal("Nenad", actual.Ride.TaxiDriverName);
            }
        }

        [Fact]
        public async Task OrderRide_TaxiNotAvailable()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var taxiRepository = mock.Mock<ITaxiRepository>();
                taxiRepository.Setup(x => x.GetAll())
                              .Returns(_taxiList);

                var rideRepository = mock.Mock<IRideRepository>();
                rideRepository.Setup(x => x.Insert(It.IsAny<Ride>()))
                              .Returns(Guid.NewGuid().ToString);

                var handler = new OrderRideCommandHandler(_mapper, taxiRepository.Object, rideRepository.Object);

                //Act
                var actual = await handler.Handle(new OrderRideCommand { LocationFrom = 99, LocationTo = 45, RideType = 0, Time = new DateTime(2022, 1, 1, 23, 0, 0) }, new CancellationToken());

                //Assert
                Assert.False(actual.RideOrdered);
            }
        }
    }
}
