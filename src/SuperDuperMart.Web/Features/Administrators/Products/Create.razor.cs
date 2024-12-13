using Blazored.Toast;
using SuperDuperMart.Web.Extensions;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Create
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public ProductCreateDto Model { get; set; } = new();

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
            NavigationManager.NavigateTo("/manage/products");
        }

        private void Cancel() => NavigationManager.NavigateTo("/manage/products");
    }
}
