using TaxiDispatcher.Common.Extensions;
using TaxiDispatcher.Repository.Model;

namespace TaxiDispatcher.InMemoryDatabase
{
    public class TaxiList : List<Taxi>
    {
        private readonly Dictionary<string, List<Taxi>> taxiIdIndex = new Dictionary<string, List<Taxi>>();

        public new void Add(Taxi taxi)
        {
            if (taxi == null) return;

            taxiIdIndex.AddOrUpdate(taxi.Id,
                index =>
                {
                    index.Add(taxi);
                    return index;
                },
                () => new List<Taxi> { taxi });


            base.Add(taxi);
        }

        public List<Taxi> GetByTaxiId(string taxiId)
        {
            List<Taxi> taxi = new List<Taxi>();
            var success = taxiIdIndex.TryGetValue(taxiId, out var taxis);

            if (success)
            {
                return taxis;
            }
            else
            {
                taxi = FindAll(x => x.Id.Equals(taxiId));
                if (taxi != null && taxi.Any())
                {
                    taxiIdIndex.AddOrUpdate(taxi.First().Id,
                    index => { },
                    () => taxi);
                }
            }
            return taxi;
        }
    }
}
