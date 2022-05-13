using System.Net.Http.Json;
using System.Text;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;

namespace TaxiDispatcher.Client.RestComunication
{
    public static class RestService
    {
        static HttpClient _httpClient = new HttpClient();
        static string _path = "http://localhost:5180/";

        public static OrderRideResponse OrderRide(OrderRideRequest orderRideRequest)
        {
            try
            {
                OrderRideResponse orderRideResponse = null;
                var url = new Uri($"{_path}api/ride/orderride");
                var stringContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(orderRideRequest), Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(url, stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    orderRideResponse =  response.Content.ReadFromJsonAsync<OrderRideResponse>().Result;
                }
                return orderRideResponse;
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
    }
}
