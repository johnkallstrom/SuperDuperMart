using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public bool Loading { get; set; }
        public IEnumerable<ProductModel>? Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            Loading = true;
            Model = await HttpService.GetAsync<IEnumerable<ProductModel>>(Endpoints.Products);
            Loading = false;
        }
    }
}
