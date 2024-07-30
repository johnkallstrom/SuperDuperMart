using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace SuperDuperMart.Web.AuthenticationProviders
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return await SetStateAsAnonymous();
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
