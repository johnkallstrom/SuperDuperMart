using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast;
using Blazored.Toast.Services;
using SuperDuperMart.Web.Features.Components.Modals;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Details
    {
        [CascadingParameter]
        public IModalService ModalService { get; set; } = default!;

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
            parameters.Add(nameof(InfoToast.Message), $"Saved");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private async Task DeleteProduct()
        {
            var modalParameters = new ModalParameters
            {
                { nameof(DeleteConfirmationModal.Message), $"Are you sure you want to delete {Model.Name}?" }
            };

            var modalReference = ModalService.Show<DeleteConfirmationModal>(modalParameters);
            var modalResult = await modalReference.Result;

            if (modalResult.Confirmed)
            {

                await HttpService.DeleteAsync($"{Endpoints.Products}/{Id}");
                NavigationManager.NavigateTo("/manage/products");
            }
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
