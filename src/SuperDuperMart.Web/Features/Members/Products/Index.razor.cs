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

        public string SelectedSortBy { get; set; } = "Created";
        public string SelectedSortOrder { get; set; } = "Desc";

        public List<SelectOption> SortOptions { get; set; } = new()
        {
            new SelectOption("Latest", "Created", SortOrder.Descending),
            new SelectOption("Name (A-Z)", "Name", SortOrder.Ascending),
            new SelectOption("Name (Z-A)", "Name", SortOrder.Descending),
            new SelectOption("Price Low", "Price", SortOrder.Ascending),
            new SelectOption("Price High", "Price", SortOrder.Descending)
        };

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model.PageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            Model.PageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");

            await GetProducts();
            Loading = false;
        }

        private async Task HandleSortSelection((string Value, SortOrder Order) selection)
        {
            SelectedSortBy = selection.Value;

            switch(selection.Order)
            {
                case SortOrder.Ascending:
                    SelectedSortOrder = "Asc";
                    break;
                case SortOrder.Descending:
                    SelectedSortOrder = "Desc";
                    break;
            }

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
            string url = $"{Endpoints.Products}?pageNumber={Model.PageNumber}&pageSize={Model.PageSize}&sortBy={SelectedSortBy}&sortOrder={SelectedSortOrder}";

            var data = await HttpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data != null)
            {
                Model = data;
            }
        }
    }
}
