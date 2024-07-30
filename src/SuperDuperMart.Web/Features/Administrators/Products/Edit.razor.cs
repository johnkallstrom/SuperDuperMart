using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Edit
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool Loading { get; set; }
        public ProductModel? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            Loading = true;
            Model = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
            Loading = false;
        }
    }
}
