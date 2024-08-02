using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Products
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        private bool _loading = true;
        public ProductModel? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            Model = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
            _loading = false;
        }
    }
}
