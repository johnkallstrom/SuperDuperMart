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
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<TData>();
                if (data != null)
                {
                    return data;
                }
            }

            return default;
        }
    }
}