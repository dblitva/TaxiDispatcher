namespace TaxiDispatcher.Repository.Model
{
    public class Taxi
    {
        public Taxi()
        {
            Company = new TaxiCompany();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public TaxiCompany Company { get; set; }    
    }
}
