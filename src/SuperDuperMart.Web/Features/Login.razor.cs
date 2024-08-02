using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

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
        public LoginModel Model { get; set; } = new();
        public bool Loading { get; set; }

        private async Task Submit()
        {
            Loading = true;

            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model);
            await AuthenticationService.BeginUserSessionAsync(token);
            NavigationManager.NavigateTo(_redirectUrl);

            Loading = false;
        }
    }
}
