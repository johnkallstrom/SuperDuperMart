using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Customers.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public bool Loading { get; set; }
        public IEnumerable<ProductModel>? Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            await GetProducts();
            Loading = false;
        }

        private async Task GetProducts()
        {
            Model = await HttpService.GetAsync<IEnumerable<ProductModel>>(Endpoints.Products);
        }
    }
}
