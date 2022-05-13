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
            return await ResponseProcessing(response);
        }

        public static async Task<ResponseWrapper<T>> GetData(Uri url)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            return await ResponseProcessing(response);
        }

        private static async Task<ResponseWrapper<T>> ResponseProcessing(HttpResponseMessage response)
        {
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
                var dic = new Dictionary<string, string[]>();
                var msg = new List<string> { "Server Error!" };
                dic.Add("Fatal", msg.ToArray());
               
                return new ResponseWrapper<T>
                {
                    IsBadResponse = true,
                    ValidationResponse = new ValidationResponse
                    {
                        status = 500,
                        title = "Server Error!",
                        errors = dic
                    }
                };
            }
        }
    }
}
