﻿namespace SuperDuperMart.Web.Features.Administrators.Users
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PagedListDto<UserDto> Model { get; set; } = default!;

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

            var result = await HttpService.GetAsync<PagedListDto<UserDto>>(url);
            if (result != null)
            {
                Model = result;
            }

            _loading = false;
        }

        private async Task HandlePreviousClick(int pageNumber)
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
