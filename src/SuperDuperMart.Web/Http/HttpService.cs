using System.Net.Http.Json;

namespace SuperDuperMart.Web.Http
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TData?> GetAsync<TData>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadFromJsonAsync<TData>();
                if (data != null)
                {
                    return data;
                }
            }

            return default;
        }
    }
}