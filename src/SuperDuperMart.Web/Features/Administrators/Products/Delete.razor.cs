using Microsoft.AspNetCore.Components;

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

        private async Task DeleteProduct()
        {
            await HttpService.DeleteAsync($"{Endpoints.Products}/{Id}");
            NavigationManager.NavigateTo("/manage/products");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
