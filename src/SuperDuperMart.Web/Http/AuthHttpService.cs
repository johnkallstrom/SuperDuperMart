using System.Net.Http.Json;

namespace SuperDuperMart.Web.Http
{
    public class AuthHttpService : IAuthHttpService
    {
        private readonly HttpClient _httpClient;

        public AuthHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendLoginRequest(string email, string password, bool isAdministrator = false)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(Endpoints.Authentication, new 
            { 
                Email = email, 
                Password = password, 
                IsAdministrator = isAdministrator 
            });

            if (httpResponse.IsSuccessStatusCode)
            {
                // Read content
            }
        }
    }
}
