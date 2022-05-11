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
    public class TaxiRepository : ITaxiRepository
    {
        private readonly InMemoryDatabaseContext _inMemoryDatabaseContext;
        public TaxiRepository(InMemoryDatabaseContext inMemoryDatabaseContext)
        {
            _inMemoryDatabaseContext = inMemoryDatabaseContext;
        }
        public List<Taxi> GetAll()
        {
            return new List<Taxi>
            {
                new Taxi { Id = Guid.NewGuid().ToString(), Name = "Pera"},
                new Taxi { Id = Guid.NewGuid().ToString(), Name = "Mika"}
            };
        }

        public Taxi GetById(string Id)
        {
            return _inMemoryDatabaseContext.Taxies.GetByTaxiId(Id);
        }

        public string Insert(Taxi taxi)
        {
            _inMemoryDatabaseContext.Taxies.Add(taxi);
            return taxi.Id;
        }
    }
}
