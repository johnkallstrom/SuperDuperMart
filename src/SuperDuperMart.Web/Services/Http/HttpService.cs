using System.Net.Http.Json;

namespace SuperDuperMart.Web.Services.Http
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

        public async Task PostAsync(string url) => await _httpClient.PostAsync(url, null);
        public async Task PostAsync<T>(string url, T value) => await _httpClient.PostAsJsonAsync(url, value);

        public async Task<string?> PostAndRetrieveStringAsync<T>(string url, T value)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, value);
            if (httpResponse.IsSuccessStatusCode)
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }

            return default;
        }

        public async Task<int?> PostAndRetrieveIntAsync<T>(string url, T value)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, value);
            if (httpResponse.IsSuccessStatusCode)
            {
                string? content = await httpResponse.Content.ReadAsStringAsync();
                if (int.TryParse(content, out int data))
                {
                    return data;
                }
            }

            return default;
        }

        public async Task PutAsync<T>(string url, T value) => await _httpClient.PutAsJsonAsync(url, value);
        public async Task DeleteAsync(string url) => await _httpClient.DeleteAsync(url);
    }
}