using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public ResultDto<UserDto> Model { get; set; } = default!;

        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            int pageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            int pageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");

            Model = new(pageNumber, pageSize);

            await GetUsers(Model.PageNumber, Model.PageSize);
        }

        private async Task GetUsers(int pageNumber, int pageSize)
        {
            string url = $"{Endpoints.Users}?pageNumber={pageNumber}&pageSize={pageSize}";

            var data = await HttpService.GetAsync<ResultDto<UserDto>>(url);
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
