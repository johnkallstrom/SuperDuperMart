using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DataTransferObjects;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool _loading = true;

        public string SortBy { get; set; } = "Created";
        public string SortOrder { get; set; } = "Desc";
        public PagedListDto<ProductDto> Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            int pageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            int pageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");

            Model = new(pageNumber, pageSize);

            await GetProducts(Model.PageNumber, Model.PageSize, SortBy, SortOrder);
        }

        private async Task GetProducts(
            int pageNumber, 
            int pageSize, 
            string? sortBy, 
            string? sortOrder)
        {
            string? url = string.Empty;

            if (!string.IsNullOrWhiteSpace(SortBy) && !string.IsNullOrWhiteSpace(SortOrder))
            {
                url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={SortBy}&sortOrder={SortOrder}";
            }
            else
            {
                url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}";
            }

            var result = await HttpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (result != null)
            {
                Model = result;
            }

            _loading = false;
        }

        private void HandleSortChange(ChangeEventArgs args)
        {
            Console.WriteLine(args);
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize, SortBy, SortOrder);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize, SortBy, SortOrder);
        }
    }
}
