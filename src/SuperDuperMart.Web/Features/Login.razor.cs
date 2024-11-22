using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DataTransferObjects;

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


        private readonly string _redirectUrl = "/";
        private bool _loading = false;

        public LoginDto Model { get; set; } = new();

        private async Task Submit()
        {
            _loading = true;
            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model); 
            if (!string.IsNullOrWhiteSpace(token))
            {
                await AuthenticationService.BeginUserSessionAsync(token);
                NavigationManager.NavigateTo(_redirectUrl);
            }

            _loading = false;
        }
    }
}
