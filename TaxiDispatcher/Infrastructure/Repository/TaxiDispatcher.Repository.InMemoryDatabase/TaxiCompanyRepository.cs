using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.InMemoryDatabase
{
    public class TaxiCompanyRepository : ITaxiCompanyRepository
    {
        private readonly InMemoryDatabaseContext _inMemoryDatabaseContext;
        public TaxiCompanyRepository(InMemoryDatabaseContext inMemoryDatabaseContext)
        {
            _inMemoryDatabaseContext = inMemoryDatabaseContext;
        }

        public TaxiCompany GetByName(string name)
        {
            return _inMemoryDatabaseContext.TaxiCompanies.GetByTaxiCompanyName(name);
        }

        public string Insert(TaxiCompany taxiCompany)
        {
            _inMemoryDatabaseContext.TaxiCompanies.Add(taxiCompany);
            return taxiCompany.Id;
        }
    }
}
