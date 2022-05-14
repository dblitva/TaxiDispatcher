using Autofac.Extras.Moq;
using Microsoft.Extensions.Logging;
using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.InMemoryDatabase;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Repository
{
    public class TaxiRepositoryTests
    {
        [Fact]
        public void TaxiRepository_GetAll()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Taxi taxi = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Predrag", Location = 50 };
                Taxi taxi1 = new Taxi { Id = Guid.NewGuid().ToString(), Name = "Nenad", Location = 60 };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;
                context.Taxis.Add(taxi);
                context.Taxis.Add(taxi1);
                
                var taxiRepository = mock.Create<TaxiRepository>();

                //Act
                var taxis = taxiRepository.GetAll();

                //Assert
                Assert.NotEmpty(taxis);

            }
        }

        [Fact]
        public void TaxiRepository_Insert()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Taxi taxi = new Taxi { Name = "Predrag", Location = 50 };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;

                var taxiRepository = mock.Create<TaxiRepository>();

                //Act
                taxiRepository.Insert(taxi);

                //Assert
                Assert.Single(context.Taxis);

            }
        }

    }
}
