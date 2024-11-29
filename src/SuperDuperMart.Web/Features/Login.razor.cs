using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features
{
    public partial class Login
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private bool Loading;

        public LoginRequest Model { get; set; } = new();

        private async Task Submit()
        {
            Loading = true;

            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model); 
            if (!string.IsNullOrWhiteSpace(token))
            {
                await AuthenticationService.BeginUserSessionAsync(token);
                NavigationManager.NavigateTo("/");
            }
            else
            {
                var parameters = new ToastParameters();
                parameters.Add(nameof(ErrorToast.Message), "Failed to login");

                ToastService.ShowToast<ErrorToast>(parameters);
            }

            Loading = false;
        }
    }
}
