namespace TaxiDispatcher.Client.Model.Response
{
    public class ResponseWrapper<T>
    {
        public bool IsBadResponse { get; set; } 
        public T? Response { get; set; }
        public ValidationResponse? ValidationResponse { get; set; }
    }
}
