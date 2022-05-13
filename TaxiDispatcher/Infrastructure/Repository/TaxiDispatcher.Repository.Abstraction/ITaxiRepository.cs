using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.Repository.Abstraction
{
    public interface ITaxiRepository
    {
        List<Taxi> GetAll();

        string Insert(Taxi taxi);
    }
}
