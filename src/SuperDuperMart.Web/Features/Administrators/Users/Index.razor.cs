using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;

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
            Loading = true;
            await GetUsers();
            Loading = false;
        }

        private async Task GetUsers()
        {
            Model = await HttpService.GetAsync<IEnumerable<UserModel>>(Endpoints.Users);
        }
    }
}
