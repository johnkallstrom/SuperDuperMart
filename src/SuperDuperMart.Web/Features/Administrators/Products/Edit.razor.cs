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
        public ProductUpdateModel Model { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            Loading = true;
            var product = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
            if (product != null)
            {
                Map(product);
            }

            Loading = false;
        }

        private void Map(ProductModel product)
        {
            Model.Name = product.Name;
            Model.Description = product.Description;
            Model.Price = product.Price;
            Model.Material = product.Material;
        }

        private async Task Submit()
        {
            Console.WriteLine(Model.Name);
            Console.WriteLine(Model.Price);
        }
    }
}
