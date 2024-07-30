using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SuperDuperMart.Web.AuthenticationProviders
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ISessionStorageService _sessionStorage;

        public JwtAuthenticationStateProvider(ISessionStorageService sessionStorage, HttpClient httpClient)
        {
            _sessionStorage = sessionStorage;
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _sessionStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrWhiteSpace(token))
            {
                return await SetStateAsAnonymous();
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await SetStateAsAuthenticated();
        }

        private async Task<AuthenticationState> SetStateAsAnonymous()
        {
            var anonymous = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(anonymous);
            
            return await Task.FromResult(new AuthenticationState(principal));
        }

        private async Task<AuthenticationState> SetStateAsAuthenticated()
        {
            var authenticated = new ClaimsIdentity(authenticationType: "jwt");
            var principal = new ClaimsPrincipal(authenticated);

            return await Task.FromResult(new AuthenticationState(principal));
        }
    }
}
