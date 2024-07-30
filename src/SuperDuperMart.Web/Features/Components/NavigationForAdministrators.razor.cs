using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class NavigationForAdministrators
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ISessionStorageService SessionStorage { get; set; } = default!;

        private async Task Logout()
        {
            await SessionStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/", forceLoad: true);
        }
    }
}
