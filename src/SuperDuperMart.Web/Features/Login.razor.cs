using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features
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
        public bool Loading { get; set; }

        private async Task Submit()
        {
            Loading = true;
            await AuthHttpService.SendLoginRequest(Model.Email, Model.Password, Model.IsAdministrator);
            Loading = false;
        }
    }
}
