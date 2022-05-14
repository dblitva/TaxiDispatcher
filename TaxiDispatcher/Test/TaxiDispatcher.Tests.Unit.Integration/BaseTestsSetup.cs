using Microsoft.AspNetCore.Mvc.Testing;

namespace TaxiDispatcher.Tests.Unit.Integration
{
    public class BaseTestsSetup
    {
        protected readonly HttpClient _httpClient;
        public BaseTestsSetup()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {

                });

            _httpClient = application.CreateClient();
        }



    }
}
