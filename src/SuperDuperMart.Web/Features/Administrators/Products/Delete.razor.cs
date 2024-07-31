using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Delete
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

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

        private async Task DeleteProduct()
        {
            await HttpService.DeleteAsync($"{Endpoints.Products}/{Id}");
            NavigationManager.NavigateTo("/manage/products");
        }
        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
