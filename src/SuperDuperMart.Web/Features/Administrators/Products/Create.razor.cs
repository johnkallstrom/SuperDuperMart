using Blazored.Toast;
using Blazored.Toast.Services;
using SuperDuperMart.Web.Features.Components.Toasts;

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

        public ProductCreateDto Model { get; set; } = new();

        public List<SelectOption> CategoryOptions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await GetCategories();
        }

        private async Task GetCategories()
        {
            var categories = await HttpService.GetAsync<IEnumerable<ProductCategoryDto>>($"{Endpoints.Products}");
        }

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Products}", Model);

            var parameters = new ToastParameters();
            parameters.Add(nameof(InfoToast.Message), "New product added");

            ToastService.ShowToast<InfoToast>(parameters);
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
