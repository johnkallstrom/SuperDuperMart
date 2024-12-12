using Blazored.Toast;
using Blazored.Toast.Services;
using SuperDuperMart.Web.Extensions;
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

        public ToastParameters ToastParameters { get; set; } = new();
        public List<SelectOption> CategoryOptions { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            await GetProductCategories();
        }

        private async Task GetProductCategories()
        {
            var categories = await HttpService.GetAsync<IEnumerable<ProductCategoryDto>>(Endpoints.ProductCategories);
            CategoryOptions = categories is not null ? categories.ToSelectOptionList() : [];
        }

        private async Task Submit()
        {
            await HttpService.PostAsync($"{Endpoints.Products}", Model);
            ToastParameters.Add(nameof(InfoToast.Message), "New product added");
            ToastService.ShowToast<InfoToast>(ToastParameters);
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
