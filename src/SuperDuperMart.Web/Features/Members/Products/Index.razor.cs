using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using SuperDuperMart.Shared.DTOs;
using SuperDuperMart.Web.Rendering.Enums;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool Loading = true;

        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }

        public List<SelectOption> Options { get; set; } = new()
        {
            new SelectOption("Latest", "Created", SortOrderType.Descending),
            new SelectOption("Name (A-Z)", "Name", SortOrderType.Ascending),
            new SelectOption("Name (Z-A)", "Name", SortOrderType.Descending),
            new SelectOption("Price Low", "Price", SortOrderType.Ascending),
            new SelectOption("Price High", "Price", SortOrderType.Descending)
        };

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            InitializeDefaultValues();
            await GetProducts();
            Loading = false;
        }

        private async Task HandleSelection((string Value, SortOrderType Order) selection)
        {
            SortBy = selection.Value;
            SortOrder = selection.Order is SortOrderType.Descending ? "Desc" : "Asc";

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

        private void InitializeDefaultValues()
        {
            SortBy = Configuration.GetValue<string>("Sorting:Products:Default:By");
            SortOrder = Configuration.GetValue<string>("Sorting:Products:Default:Order");
            Model.PageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            Model.PageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");
        }
    }
}
