using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface IRideRepository
    {
        Ride GetById(string Id);
        string Insert(Ride ride);
    }
}
