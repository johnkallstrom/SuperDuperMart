using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        //[Inject]
        //public ISessionStorageService SessionStorage { get; set; } = default!;

        public LoginModel Model { get; set; } = new();
        public bool Loading { get; set; }

        private async Task Submit()
        {
            Loading = true;

            string? token = await HttpService.PostAndRetrieveStringAsync(Endpoints.Authentication, Model);
            if (!string.IsNullOrEmpty(token))
            {
                await LocalStorage.SetItemAsStringAsync("token", token);
                NavigationManager.NavigateTo("/");
            }

            Loading = false;
        }
    }
}
