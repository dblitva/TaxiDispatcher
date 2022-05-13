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
            return _inMemoryDatabaseContext.Taxis;
        }

        public string Insert(Taxi taxi)
        {
            _inMemoryDatabaseContext.Taxis.Add(taxi);
            return taxi.Id;
        }
    }
}
