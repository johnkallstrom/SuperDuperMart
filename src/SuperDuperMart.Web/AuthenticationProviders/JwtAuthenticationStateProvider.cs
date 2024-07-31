using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using Blazored.LocalStorage;
using SuperDuperMart.Web.Services;

namespace SuperDuperMart.Web.AuthenticationProviders
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly ISessionStorageService _sessionStorage;

        public JwtAuthenticationStateProvider(
            ISessionStorageService sessionStorage,
            HttpClient httpClient,
            ILocalStorageService localStorage,
            IJwtHandler jwtHandler)
        {
            _sessionStorage = sessionStorage;
            _httpClient = httpClient;
            _localStorage = localStorage;
            _jwtHandler = jwtHandler;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _localStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrWhiteSpace(token) || _jwtHandler.HasTokenExpired(token))
            {
                return await SetStateAsAnonymous();
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var claims = _jwtHandler.ReadClaimsFromToken(token);
            return await SetStateAsAuthenticated(claims.ToList());
        }

        private async Task<AuthenticationState> SetStateAsAnonymous()
        {
            var anonymous = new ClaimsIdentity();
            var principal = new ClaimsPrincipal(anonymous);
            
            return await Task.FromResult(new AuthenticationState(principal));
        }

        private async Task<AuthenticationState> SetStateAsAuthenticated(List<Claim> claims)
        {
            var authenticated = new ClaimsIdentity(claims, authenticationType: "jwt");
            var principal = new ClaimsPrincipal(authenticated);

            return await Task.FromResult(new AuthenticationState(principal));
        }
    }
}
