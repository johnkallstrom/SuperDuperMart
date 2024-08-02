using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool _loading = true;
        public IEnumerable<ProductModel>? Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            Model = await HttpService.GetAsync<IEnumerable<ProductModel>>(Endpoints.Products);
            _loading = false;
        }
    }
}
