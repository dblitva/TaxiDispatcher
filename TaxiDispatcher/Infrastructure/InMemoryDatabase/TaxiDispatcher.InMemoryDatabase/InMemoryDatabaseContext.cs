namespace TaxiDispatcher.InMemoryDatabase
{
    public class InMemoryDatabaseContext
    {
        public InMemoryDatabaseContext()
        {
            Rides = new RideList();
            Taxies = new TaxiList();
        }

        public RideList Rides { get; set; }
        public TaxiList Taxies{ get; set; }
    }
}
