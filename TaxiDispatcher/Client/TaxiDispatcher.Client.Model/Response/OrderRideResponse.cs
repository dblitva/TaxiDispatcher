namespace TaxiDispatcher.Client.Model.Response
{
    public class OrderRideResponse
    {
        public bool RideOrdered { get; set; }
        public string OrderCancelationReason { get; set; }
        public RideData Ride { get; set; }
    }
    public class RideData
    {
        public string Id { get; set; }
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public string TaxiDriverId { get; set; }
        public string TaxiDriverName { get; set; }
        public int Price { get; set; }
    }
}
