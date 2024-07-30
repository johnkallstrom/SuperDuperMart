using SuperDuperMart.Shared.Models.Authentication;
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

        public async Task<LoginResult> SendLoginRequest(string email, string password, bool isAdministrator = false)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(Endpoints.Authentication, new 
            { 
                Email = email, 
                Password = password, 
                IsAdministrator = isAdministrator 
            });

            if (httpResponse.IsSuccessStatusCode)
            {
                var loginResult = await httpResponse.Content.ReadFromJsonAsync<LoginResult>();
                if (loginResult != null)
                {
                    return loginResult;
                }
            }

            return new LoginResult { Success = false, Token = null };
        }
    }
}
