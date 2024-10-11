using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features
{
    public partial class Index
    {
        [Inject]
        public IJwtHandler JwtHandler { get; set; } = default!;

        [Inject]
        public ISessionStorageService SessionStorage { get; set; } = default!;

        public int TokenExpirationTimeInMinutes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TokenExpirationTimeInMinutes = await GetTokenExpirationTime();
        }

        private async Task<int> GetTokenExpirationTime()
        {
            string? token = await SessionStorage.GetItemAsStringAsync("token");
            return JwtHandler.GetTokenExpirationTimeInMinutes(token);
        }
    }
}
