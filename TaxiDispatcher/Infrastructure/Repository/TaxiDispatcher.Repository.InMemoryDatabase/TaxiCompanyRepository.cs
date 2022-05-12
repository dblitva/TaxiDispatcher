using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public List<TaxiCompany> GetAll()
        {
            return _inMemoryDatabaseContext.TaxiCompanies;
        }

        public TaxiCompany GetById(string Id)
        {
            return _inMemoryDatabaseContext.TaxiCompanies.GetByTaxiCompanyId(Id);
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
