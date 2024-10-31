using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Create
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public ProductCreateModel Model { get; set; } = new();

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Products}", Model);
            ToastService.ShowWarning("Saved");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
