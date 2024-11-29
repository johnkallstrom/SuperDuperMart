using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Features
{
    public partial class Login
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private bool Loading = true;

        public LoginRequest Model { get; set; } = new();

        private async Task Submit()
        {
            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model); 
            if (!string.IsNullOrWhiteSpace(token))
            {
                await AuthenticationService.BeginUserSessionAsync(token);
                NavigationManager.NavigateTo("/");
            }

            Loading = false;
        }
    }
}
