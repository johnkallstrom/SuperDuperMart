using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Shared.Models.Users;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PaginatedModel<UserModel> Model { get; set; } = new(pageNumber: 1, pageSize: 10);

        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await GetUsers(Model.PageNumber, Model.PageSize);
        }

        private async Task GetUsers(int pageNumber, int pageSize)
        {
            string url = $"{Endpoints.Users}?pageNumber={pageNumber}&pageSize={pageSize}";

            var data = await HttpService.GetAsync<PaginatedModel<UserModel>>(url);
            if (data != null)
            {
                Model = data;
            }

            _loading = false;
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetUsers(Model.PageNumber, Model.PageSize);
        }

        private async Task HandlePageClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetUsers(Model.PageNumber, Model.PageSize);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetUsers(Model.PageNumber, Model.PageSize);
        }
    }
}
