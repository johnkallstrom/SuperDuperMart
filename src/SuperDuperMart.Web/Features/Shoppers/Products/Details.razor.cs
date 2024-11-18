using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Shoppers.Products
{
    public partial class Details
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        private bool _loading = true;
        public ProductDto? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            Model = await HttpService.GetAsync<ProductDto>($"{Endpoints.Products}/{Id}");
            _loading = false;
        }
    }
}
