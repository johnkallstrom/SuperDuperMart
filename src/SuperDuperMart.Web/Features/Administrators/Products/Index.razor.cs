using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<ProductModel>? Model { get; set; } = default!;

        private bool _loading = true;

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
