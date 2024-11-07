using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Update
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        private bool _loading = true;

        public ProductUpdateModel Model { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            var product = await HttpService.GetAsync<ProductModel>($"{Endpoints.Products}/{Id}");
            if (product != null)
            {
                Map(product);
                _loading = false;
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

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), $"Updated product");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
