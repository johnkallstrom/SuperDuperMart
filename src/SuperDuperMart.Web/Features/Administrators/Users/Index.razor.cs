using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Shared.Models.Users;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PaginatedModel<UserModel>? Model { get; set; } = new(pageNumber: 1, pageSize: 10);
        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            string url = $"{Endpoints.Users}?pageNumber={Model?.PageNumber}&pageSize={Model?.PageSize}";

            Model = await HttpService.GetAsync<PaginatedModel<UserModel>>(url);

            _loading = false;
        }

        private async Task Previous(int pageNumber)
        {
            if (Model != null)
            {
                Model.PageNumber = pageNumber;
            }

            await GetUsers();
        }

        private async Task Next(int pageNumber)
        {
            if (Model != null)
            {
                Model.PageNumber = pageNumber;
            }

            await GetUsers();
        }
    }
}
