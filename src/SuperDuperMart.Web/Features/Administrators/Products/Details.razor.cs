using AutoMapper;
using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Details
    {
        [Inject]
        public IMapper Mapper { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int Id { get; set; }

        public bool Loading { get; set; } = true;

        public ProductUpdateDto Model { get; set; } = new();

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            var productDto = await HttpService.GetAsync<ProductDto>($"{Endpoints.Products}/{Id}");
            if (productDto != null)
            {
                Model = Mapper.Map<ProductUpdateDto>(productDto);
                Loading = false;
            }
        }

        private async Task UpdateProduct()
        {
            await HttpService.PutAsync($"{Endpoints.Products}/{Id}", Model);

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), $"Updated product");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private async Task DeleteProduct()
        {
            await HttpService.DeleteAsync($"{Endpoints.Products}/{Id}");
            NavigationManager.NavigateTo("/manage/products");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
