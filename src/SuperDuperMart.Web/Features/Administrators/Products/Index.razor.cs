namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PagedListDto<ProductDto> Model { get; set; } = default!;

        private string? SortBy;
        private string? SortOrder;
        private bool Loading = true;

        protected override async Task OnInitializedAsync()
        {
            int pageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            int pageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");
            SortBy = "Created";
            SortOrder = "Desc";

            Model = new(pageNumber, pageSize);

            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task GetProducts(int pageNumber, int pageSize)
        {
            string? url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={SortBy}&sortOrder={SortOrder}";

            var result = await HttpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (result != null)
            {
                Model = result;
            }

            Loading = false;
        }

        private async void HandleSortableTableHeaderClick((string SortBy, string SortOrder) result)
        {
            SortBy = result.SortBy;
            SortOrder = result.SortOrder;

            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }
    }
}
