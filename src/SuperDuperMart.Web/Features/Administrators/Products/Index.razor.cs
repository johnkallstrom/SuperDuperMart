using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<ProductModel>? Model { get; set; } = default!;

        private bool _loading = true;
        private int _currentPage = 1;
        private int _pageSize = 10;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            Model = await HttpService.GetAsync<IEnumerable<ProductModel>>($"{Endpoints.Products}?currentPage={_currentPage}&pageSize={_pageSize}");
            _loading = false;
        }

        private async Task Previous(int currentPage)
        {
            _currentPage = currentPage;
            await GetProducts();
        }

        private async Task Next(int currentPage)
        {
            _currentPage = currentPage;
            await GetProducts();
        }
    }
}
