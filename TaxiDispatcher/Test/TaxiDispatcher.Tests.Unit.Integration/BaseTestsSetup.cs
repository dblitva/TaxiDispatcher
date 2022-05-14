using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using TaxiDispatcher.Client.Helper;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;

namespace TaxiDispatcher.Tests.Unit.Integration
{
    public class BaseTestsSetup
    {
        private readonly HttpClient _httpClient;
        private readonly string _path;
        public BaseTestsSetup()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {

                });

            _httpClient = application.CreateClient();
            _path = "http://localhost:5180/";
        }

        public async Task<ResponseWrapper<OrderRideResponse>> OrderRide(OrderRideRequest orderRideRequest)
        {
            var url = new Uri($"{_path}api/ride/orderride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderRideRequest), Encoding.UTF8, "application/json");
            return await HttpClientWrapper<OrderRideResponse>.PostData(_httpClient, url, stringContent);
        }

        public async Task<ResponseWrapper<string>> AcceptRide(AcceptRideRequest acceptRideRequest)
        {
            var url = new Uri($"{_path}api/ride/acceptride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(acceptRideRequest), Encoding.UTF8, "application/json");
            return await HttpClientWrapper<string>.PostData(_httpClient, url, stringContent);
        }

        public async Task<ResponseWrapper<List<RidesByDriverResponse>>> GetRidesByDate(DateTime date)
        {
            var url = new Uri($"{_path}api/ride/getridesbyday?Date={date}");
            return await HttpClientWrapper<List<RidesByDriverResponse>>.GetData(_httpClient, url);
        }

    }
}
