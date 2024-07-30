using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public bool Loading { get; set; }
        public IEnumerable<UserModel>? Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            Loading = true;
            Model = await HttpService.GetAsync<IEnumerable<UserModel>>(Endpoints.Users);
            Loading = false;
        }
    }
}
