using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Create
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public ProductCreateModel Model { get; set; } = new();

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Products}", Model);
            NavigationManager.NavigateTo("/manage/products");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
