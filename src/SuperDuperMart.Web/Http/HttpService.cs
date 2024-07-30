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

        public async Task<T?> GetAsync<T>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadFromJsonAsync<T>();
                if (data != null)
                {
                    return data;
                }
            }

            return default;
        }

        public async Task<string> PostAsync<T>(string url, T value)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, value);
            if (httpResponse.IsSuccessStatusCode)
            {
                string str = await httpResponse.Content.ReadAsStringAsync();
                return str;
            }

            return string.Empty;
        }
    }
}