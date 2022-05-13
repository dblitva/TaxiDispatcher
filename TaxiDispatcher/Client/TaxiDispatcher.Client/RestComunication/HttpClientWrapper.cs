using System.Net.Http.Json;
using TaxiDispatcher.Client.Model.Response;

namespace TaxiDispatcher.Client.RestComunication
{
    public static class HttpClientWrapper<T>
    {
        public static async Task<ResponseWrapper<T>> PostData(Uri url, HttpContent stringContent)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsync(url, stringContent);
            if (response.IsSuccessStatusCode)
            {
                return new ResponseWrapper<T> { Response = await response.Content.ReadFromJsonAsync<T>(), IsBadResponse = false };
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                return new ResponseWrapper<T> { ValidationResponse = await response.Content.ReadFromJsonAsync<ValidationResponse>(), IsBadResponse = true };
            }
            else
            {
                return new ResponseWrapper<T>
                {
                    IsBadResponse = true,
                    ValidationResponse = new ValidationResponse
                    {
                        status = 500,
                        title = "Server Error!",
                        errors = new Errors { LocationFrom = new List<string> { "Server Error!" } }
                    }
                };
            }
        }
    }
}
