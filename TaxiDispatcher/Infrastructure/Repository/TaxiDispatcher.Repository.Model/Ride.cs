namespace TaxiDispatcher.Repository.Model
{
    public class Ride
    {
        public Ride()
        {
            Taxi = new Taxi();
        }
        public string Id { get; set; }
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public Taxi Taxi { get; set; }
        public int Price { get; set; }
    }
}
