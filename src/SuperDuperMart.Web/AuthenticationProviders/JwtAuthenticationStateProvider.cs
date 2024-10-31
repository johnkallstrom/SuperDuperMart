using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SuperDuperMart.Web.AuthenticationProviders
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly string _authenticationType = "jwt";

        private readonly HttpClient _httpClient;
        private readonly IJwtHandler _jwtHandler;
        private readonly ILocalStorageService _localStorage;

        public JwtAuthenticationStateProvider(
            HttpClient httpClient,
            IJwtHandler jwtHandler,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _jwtHandler = jwtHandler;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string? token = await _localStorage.GetItemAsStringAsync("token");
            if (string.IsNullOrWhiteSpace(token) || _jwtHandler.HasTokenExpired(token))
            {
                var identity = new ClaimsIdentity();
                var anonymous = new ClaimsPrincipal();

                return await Task.FromResult(new AuthenticationState(anonymous));
            }
            else
            {
                var claims = _jwtHandler.ReadClaimsFromToken(token);

                var identity = new ClaimsIdentity(claims, _authenticationType);
                var authenticated = new ClaimsPrincipal(identity);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await Task.FromResult(new AuthenticationState(authenticated));
            }
        }

        public async Task MarkStateAsAuthenticated(string token)
        {
            await _localStorage.SetItemAsStringAsync("token", token);
            var claims = _jwtHandler.ReadClaimsFromToken(token);

            var identity = new ClaimsIdentity(claims, authenticationType: _authenticationType);
            var authenticated = new ClaimsPrincipal(identity);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(authenticated)));
        }

        public async Task MarkStateAsAnonymous()
        {
            await _localStorage.RemoveItemAsync("token");

            var identity = new ClaimsIdentity();
            var anonymous = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
