using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Json;
using System.Text;
using TaxiDispatcher.Client.Model.Request;
using TaxiDispatcher.Client.Model.Response;
using TaxiDispatcher.Client.RestComunication;
using TaxiDispatcher.Common;

namespace TaxiDispatcher.Client
{
    internal class Program
    {
        static HttpClient _httpClient = new HttpClient();
        static string _path = "http://localhost:5180/";
        //static void Main(string[] args)
        //{
        //    var orderRideRequest1 = new OrderRideRequest
        //    {
        //        LocationFrom = 5,
        //        LocationTo = 0,
        //        RideType = Constants.RideTypes.City,
        //        Time = new DateTime(2022, 1, 1, 23, 0, 0)
        //    };
        //    OrderRide(orderRideRequest1);

        //    var orderRideRequest2 = new OrderRideRequest
        //    {
        //        LocationFrom = 0,
        //        LocationTo = 12,
        //        RideType = Constants.RideTypes.InterCity,
        //        Time = new DateTime(2022, 1, 1, 9, 0, 0)
        //    };
        //    OrderRide(orderRideRequest2);

        //    var orderRideRequest3 = new OrderRideRequest
        //    {
        //        LocationFrom = 5,
        //        LocationTo = 0,
        //        RideType = Constants.RideTypes.City,
        //        Time = new DateTime(2022, 1, 1, 11, 0, 0)
        //    };
        //    OrderRide(orderRideRequest3);

        //    var orderRideRequest4 = new OrderRideRequest
        //    {
        //        LocationFrom = 5,
        //        LocationTo = 0,
        //        RideType = Constants.RideTypes.City,
        //        Time = new DateTime(2022, 1, 1, 11, 0, 0)
        //    };
        //    OrderRide(orderRideRequest4);


        //}

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .CreateLogger();

            Log.Logger.Information("Application Starting");

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<RestService>();
                })
                .UseSerilog()
                .Build();

            var svc = ActivatorUtilities.CreateInstance<TaxiDispatcherClient>(host.Services);
            svc.Run(host.Services).Wait();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "PROD"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}