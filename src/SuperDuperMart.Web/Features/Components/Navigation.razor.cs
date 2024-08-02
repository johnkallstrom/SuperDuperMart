using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Web.AuthenticationProviders;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Navigation
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private readonly string _redirectUrl = "/";

        private async Task HandleLogout()
        {
            var jwtAuthenticationStateProvider = AuthenticationStateProvider as JwtAuthenticationStateProvider;
            if (jwtAuthenticationStateProvider != null)
            {
                await jwtAuthenticationStateProvider.EndUserSession();
                NavigationManager.NavigateTo(_redirectUrl);
            }
        }
    }
}
