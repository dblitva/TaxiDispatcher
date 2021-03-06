using TaxiDispatcher.Common;
using TaxiDispatcher.InMemoryDatabase;
using TaxiDispatcher.Repository.Abstraction;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.InMemoryDatabase
{
    public class RideRepository : IRideRepository
    {
        private readonly InMemoryDatabaseContext _inMemoryDatabaseContext;
        public RideRepository(InMemoryDatabaseContext inMemoryDatabaseContext)
        {
            _inMemoryDatabaseContext = inMemoryDatabaseContext;
        }

        public Ride GetById(string Id)
        {
            return _inMemoryDatabaseContext.Rides.GetByRideId(Id);
        }

        public string Insert(Ride ride)
        {
            ride.Id = Guid.NewGuid().ToString();
            _inMemoryDatabaseContext.Rides.Add(ride);
            return ride.Id;
        }

        public List<Ride> GetAcceptedRidesByDay(DateTime date)
        {
            return _inMemoryDatabaseContext.Rides.Where(ride => ride.Time.Date == date.Date && ride.State == Constants.RideStates.Accepted).ToList();
        }
    }
}
