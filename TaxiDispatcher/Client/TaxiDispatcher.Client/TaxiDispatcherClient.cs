using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;
using TaxiDispatcher.Common;

namespace TaxiDispatcher.Client
{
    public class TaxiDispatcherClient
    {
        public async Task Run()
        {
            string _path = "http://localhost:5180/";
            var httpClient = new HttpClient();

            var orderRideRequest1 = new OrderRideRequest
            {
                LocationFrom = 5,
                LocationTo = 33,
                RideType = Constants.RideTypes.City,
                Time = new DateTime(2022, 1, 1, 23, 0, 0)
            };

            OrderRideResponse orderRideResponse = null;
            var url = new Uri($"{_path}api/ride/orderride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderRideRequest1), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                orderRideResponse = await response.Content.ReadFromJsonAsync<OrderRideResponse>();
            }
        }
    }
}
