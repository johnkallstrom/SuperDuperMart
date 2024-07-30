using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ISessionStorageService SessionStorage { get; set; } = default!;

        public LoginModel Model { get; set; } = new();
        public bool Loading { get; set; }

        private async Task Submit()
        {
            Loading = true;

            string? token = await HttpService.PostAsync(Endpoints.Authentication, Model);
            if (!string.IsNullOrEmpty(token))
            {
                await SessionStorage.SetItemAsStringAsync("token", token);
                NavigationManager.NavigateTo("/");
            }

            Loading = false;
        }
    }
}
