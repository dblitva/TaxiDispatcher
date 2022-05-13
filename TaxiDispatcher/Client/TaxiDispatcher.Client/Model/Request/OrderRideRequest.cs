namespace TaxiDispatcher.Client.Model.Request
{
    public class OrderRideRequest
    {
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public int RideType { get; set; }
        public DateTime Time { get; set; }
    }
}
