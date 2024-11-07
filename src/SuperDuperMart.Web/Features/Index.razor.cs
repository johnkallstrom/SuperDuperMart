using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features
{
    public partial class Index
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public IJwtHandler JwtHandler { get; set; } = default!;

        [Inject]
        public ILocalStorageService LocalStorage { get; set; } = default!;

        public int TokenExpirationTimeInMinutes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TokenExpirationTimeInMinutes = await GetTokenExpirationTime();
        }

        private async Task<int> GetTokenExpirationTime()
        {
            string? token = await LocalStorage.GetItemAsStringAsync("token");
            return JwtHandler.GetTokenExpirationTimeInMinutes(token);
        }
    }
}
