using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Web.AuthenticationProviders;

namespace SuperDuperMart.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
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
