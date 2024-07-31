using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Navigation
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        //[Inject]
        //public ISessionStorageService SessionStorage { get; set; } = default!;

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}
