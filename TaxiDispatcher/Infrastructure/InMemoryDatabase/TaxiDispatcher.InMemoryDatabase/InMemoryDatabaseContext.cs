namespace TaxiDispatcher.InMemoryDatabase
{
    public class InMemoryDatabaseContext
    {
        public InMemoryDatabaseContext()
        {
            Rides = new RideList();
            Taxis = new TaxiList();
            TaxiCompanies = new TaxiCompanyList();
        }

        public RideList Rides { get; set; }
        public TaxiList Taxis{ get; set; }
        public TaxiCompanyList TaxiCompanies{ get; set; }
    }
}
