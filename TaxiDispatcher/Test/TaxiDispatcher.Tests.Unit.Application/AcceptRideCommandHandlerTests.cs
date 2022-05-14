using Autofac.Extras.Moq;
using Moq;
using TaxiDispatcher.Application.Commands.Ride;
using TaxiDispatcher.Application.Handlers.Ride;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Application
{
    public class AcceptRideCommandHandlerTests : BaseTestsSetup
    {
        [Fact]
        public async Task AcceptRide()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var rideRepository = mock.Mock<IRideRepository>();
                rideRepository.Setup(x => x.GetById(It.IsAny<string>()))
                              .Returns( 
                                    new Ride { Id = Guid.NewGuid().ToString(), LocationFrom = 2, LocationTo = 44, Price = 567, State = 0, Time = new DateTime(2022, 1, 1, 23, 0, 0) ,
                                    Taxi = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Nenad", Location = 21, Company = new TaxiCompany { Id = Guid.NewGuid().ToString(), Name = "Gold", Rate = 12 } }
                              });

                var handler = new AcceptRideCommandHandler(rideRepository.Object);

                //Act
                var actual = await handler.Handle(new AcceptRideCommand { RideId = Guid.NewGuid().ToString() }, new CancellationToken());

                //Assert
                Assert.True(actual.RideAccepted);
            }
        }
    }
}
