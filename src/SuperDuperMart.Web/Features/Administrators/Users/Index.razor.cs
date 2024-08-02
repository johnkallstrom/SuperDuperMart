using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<UserModel>? Model { get; set; } = default!;

        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            Model = await HttpService.GetAsync<IEnumerable<UserModel>>(Endpoints.Users);
            _loading = false;
        }
    }
}
