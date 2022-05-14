namespace TaxiDispatcher.Client.Model.Response
{
    public class RidesByDriverResponse
    {
        public string DriverId { get; set; }
        public string DriverName { get; set; }
        public int Total { get; set; }
        public List<Ride> Rides { get; set; }
    }

    public class Ride
    {
        public string RideId { get; set; }
        public int Price { get; set; }
        public DateTime Time { get; set; }
    }
}
