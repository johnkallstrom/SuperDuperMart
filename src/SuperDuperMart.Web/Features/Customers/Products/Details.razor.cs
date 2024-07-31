using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Products
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool Loading { get; set; }
        public ProductModel? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            Loading = true;
            await GetProduct();
            Loading = false;
        }

        private async Task GetProduct()
        {
            Model = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
        }
    }
}
