using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface IRideRepository
    {
        Ride GetById(string Id);
        List<Ride> GetAcceptedRidesByDay(DateTime date);
        string Insert(Ride ride);
    }
}
