using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Web.AuthenticationProviders;

namespace SuperDuperMart.Web.Features
{
    public partial class Login
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;


        private readonly string _redirectUrl = "/";
        public LoginModel Model { get; set; } = new();
        public bool Loading { get; set; }

        private async Task Submit()
        {
            Loading = true;

            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model);
            var jwtAuthenticationStateProvider = AuthenticationStateProvider as JwtAuthenticationStateProvider;
            if (jwtAuthenticationStateProvider != null && !string.IsNullOrWhiteSpace(token))
            {
                await jwtAuthenticationStateProvider.BeginUserSession(token);
                NavigationManager.NavigateTo(_redirectUrl);
            }

            Loading = false;
        }
    }
}
