using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Authentication;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Authentication
{
    public partial class Login
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ISessionStorageService SessionStorage { get; set; } = default!;

        [Inject]
        public IAuthHttpService AuthHttpService { get; set; } = default!;

        public LoginModel Model { get; set; } = new();

        private async Task Submit()
        {
            var result = await AuthHttpService.SendLoginRequest(Model.Email, Model.Password, Model.IsAdministrator);
            if (result.Success)
            {
                await SessionStorage.SetItemAsStringAsync("token", result.Token);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
