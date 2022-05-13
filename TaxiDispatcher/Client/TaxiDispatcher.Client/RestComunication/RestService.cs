﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<ResponseWrapper<OrderRideResponse>> OrderRide(OrderRideRequest orderRideRequest)
        {
            var url = new Uri($"{_path}api/ride/orderride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(orderRideRequest), Encoding.UTF8, "application/json");
            return await HttpClientWrapper<OrderRideResponse>.PostData(url, stringContent);
        }

        public async Task<ResponseWrapper<string>> AcceptRide(AcceptRideRequest acceptRideRequest)
        {
            var url = new Uri($"{_path}api/ride/acceptride");
            var stringContent = new StringContent(JsonConvert.SerializeObject(acceptRideRequest), Encoding.UTF8, "application/json");
            return await HttpClientWrapper<string>.PostData(url, stringContent);
        }

        public async Task<ResponseWrapper<List<RidesByDriverResponse>>> GetRidesByDate(DateTime date)
        {
            var url = new Uri($"{_path}api/ride/getridesbyday?Date={date}");
            return await HttpClientWrapper<List<RidesByDriverResponse>>.GetData(url);
        }
    }


}