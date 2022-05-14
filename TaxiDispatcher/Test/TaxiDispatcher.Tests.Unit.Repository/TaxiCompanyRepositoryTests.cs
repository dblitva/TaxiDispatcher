using Autofac.Extras.Moq;
using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.InMemoryDatabase;
using TaxiDispatcher.Repository.Model;
using Xunit;

namespace TaxiDispatcher.Tests.Unit.Repository
{
    public class TaxiCompanyRepositoryTests
    {
        [Fact]
        public void TaxiRepository_GetByName()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                TaxiCompany taxiCompany = new TaxiCompany { Name = "Gold", Rate = 25 };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;
                context.TaxiCompanies.Add(taxiCompany);

                var taxiCompanyRepository = mock.Create<TaxiCompanyRepository>();

                //Act
                var actual = taxiCompanyRepository.GetByName(taxiCompany.Name);

                //Assert
                Assert.Equal(context.TaxiCompanies.First().Name, actual.Name);

            }
        }

        [Fact]
        public void TaxiCompanyRepository_Insert()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                TaxiCompany taxiCompany = new TaxiCompany { Name = "Gold", Rate = 25 };

                mock.Mock<InMemoryDatabaseContext>();
                var context = mock.Mock<InMemoryDatabaseContext>().Object;

                var taxiCompanyRepository = mock.Create<TaxiCompanyRepository>();

                //Act
                taxiCompanyRepository.Insert(taxiCompany);

                //Assert
                Assert.Single(context.TaxiCompanies);

            }
        }
    }
}
