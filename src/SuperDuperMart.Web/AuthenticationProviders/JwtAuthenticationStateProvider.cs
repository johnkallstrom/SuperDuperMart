using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

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

            var claims = ReadClaimsFromToken(token);
            return await SetStateAsAuthenticated(claims.ToList());
        }

        private IEnumerable<Claim> ReadClaimsFromToken(string token)
        {
            var handler = new JsonWebTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jsonWebToken = handler.ReadJsonWebToken(token);
                return jsonWebToken.Claims;
            }

            return Enumerable.Empty<Claim>();
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
