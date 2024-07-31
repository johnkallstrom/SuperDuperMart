using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Edit
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool DisplayAlert { get; set; } = false;
        public bool Loading { get; set; }
        public ProductUpdateModel Model { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            Loading = true;
            await GetProduct();
            Loading = false;
        }

        private async Task GetProduct()
        {
            var product = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
            if (product != null)
            {
                Map(product);
            }
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
            await HttpService.PutAsync($"{Endpoints.Products}/{Id}", Model);
            DisplayAlert = true;
        }

        private void ToggleAlert() => DisplayAlert = !DisplayAlert;
        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
