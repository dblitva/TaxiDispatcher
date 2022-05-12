using TaxiDispatcher.Repository.Model;
using TaxiDispatcher.Common.Extensions;

namespace TaxiDispatcher.InMemoryDatabase
{
    public class RideList : List<Ride>
    {
        private readonly Dictionary<string, List<Ride>> rideIdIndex = new Dictionary<string, List<Ride>>();

        public new void Add(Ride ride)
        {
            if (ride == null) return;

            rideIdIndex.AddOrUpdate(ride.Id,
                index =>
                {
                    index.Add(ride);
                    return index;
                },
                () => new List<Ride> { ride });
            

            base.Add(ride);
        }

        public Ride GetByRideId(string rideId)
        {
            List<Ride> ride = new List<Ride>();
            var success = rideIdIndex.TryGetValue(rideId, out var rides);

            if (success)
            {
                return rides.FirstOrDefault();
            }
            else
            {
                ride = FindAll(x => x.Id.Equals(rideId));
                if (ride != null && ride.Any())
                {
                    rideIdIndex.AddOrUpdate(ride.First().Id,
                    index => { },
                    () => ride);
                }
            }
            return ride.FirstOrDefault();
        }
    }
}
