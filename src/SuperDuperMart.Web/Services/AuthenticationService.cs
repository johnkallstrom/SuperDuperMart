using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Web.AuthenticationProviders;
using System.Security.Claims;

namespace SuperDuperMart.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<ClaimsPrincipal> GetCurrentUserAsync()
        {
            var jwtAuthStateProvider = _authStateProvider as JwtAuthenticationStateProvider;
            if (jwtAuthStateProvider != null)
            {
                var authState = await jwtAuthStateProvider.GetAuthenticationStateAsync();
                var user = authState.User;

                return user;
            }

            var identity = new ClaimsIdentity();
            var anonymous = new ClaimsPrincipal();

            return await Task.FromResult(anonymous);
        }

        public async Task BeginUserSessionAsync(string? token)
        {
            var jwtAuthStateProvider = _authStateProvider as JwtAuthenticationStateProvider;
            if (jwtAuthStateProvider != null && !string.IsNullOrWhiteSpace(token))
            {
                await jwtAuthStateProvider.MarkStateAsAuthenticated(token);
            }
        }

        public async Task EndUserSessionAsync()
        {
            var jwtAuthStateProvider = _authStateProvider as JwtAuthenticationStateProvider;
            if (jwtAuthStateProvider != null)
            {
                await jwtAuthStateProvider.MarkStateAsAnonymous();
            }
        }
    }
}
