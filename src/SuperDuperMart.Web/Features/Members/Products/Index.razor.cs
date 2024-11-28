using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool Loading = true;

        public string SortBy { get; set; } = "Created";
        public string SortOrder { get; set; } = "Desc";

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model.PageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            Model.PageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");

            await GetProducts();
            Loading = false;
        }

        private async Task HandleSortChange((string SortBy, string SortOrder) selection)
        {
            SortBy = selection.SortBy;
            SortOrder = selection.SortOrder;
            await GetProducts();
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts();
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts();
        }

        private async Task GetProducts()
        {
            string url = $"{Endpoints.Products}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}&sortBy={SortBy}&sortOrder={SortOrder}";

            var data = await HttpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data != null)
            {
                Model = data;
            }
        }
    }
}
