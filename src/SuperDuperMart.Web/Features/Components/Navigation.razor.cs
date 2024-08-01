using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Navigation
    {
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        //[Inject]
        //public ISessionStorageService SessionStorage { get; set; } = default!;

        protected override void OnInitialized()
        {
            AuthenticationStateProvider.AuthenticationStateChanged += AuthenticationStateChanged;
            NavigationManager.LocationChanged += LocationChanged;
        }

        private async void AuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var state = await task;
            Console.WriteLine($"Is Authenticated: {state.User.Identity?.IsAuthenticated}");
        }

        private void LocationChanged(object? sender, LocationChangedEventArgs e)
        {
            string locationChangedBy = e.IsNavigationIntercepted ? "HTML" : "Code";
            Console.WriteLine($"Location: {e.Location}");
            Console.WriteLine($"Changed By: {locationChangedBy}");
        }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("token");
            NavigationManager.NavigateTo("/");
        }
    }
}
