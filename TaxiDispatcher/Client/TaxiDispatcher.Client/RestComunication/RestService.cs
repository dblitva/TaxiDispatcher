using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;

namespace TaxiDispatcher.Client.RestComunication
{
    public class RestService
    {
        private readonly string _path;
        private readonly HttpClient _httpClient;

        public RestService()
        {
            _path = "http://localhost:5180/";
            _httpClient = new HttpClient();
        }

        public async Task<OrderRideResponse> OrderRide(OrderRideRequest orderRideRequest)
        {
            OrderRideResponse orderRideResponse = null;
            var url = new Uri($"{_path}api/ride/orderride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderRideRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                orderRideResponse = await response.Content.ReadFromJsonAsync<OrderRideResponse>();
            }
            return orderRideResponse;
        }

        public async Task<string> AcceptRide(AcceptRideRequest acceptRideRequest)
        {
            string orderRideResponse = null;
            var url = new Uri($"{_path}api/ride/acceptride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(acceptRideRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                orderRideResponse = await response.Content.ReadFromJsonAsync<string>();
            }
            return orderRideResponse;
        }
    }
}
