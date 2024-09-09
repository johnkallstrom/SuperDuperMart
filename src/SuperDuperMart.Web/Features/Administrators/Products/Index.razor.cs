using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public Paginated<ProductModel> Model { get; set; } = new(currentPage: 1, pageSize: 10);

        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            string? url = $"{Endpoints.Products}?currentPage={Model.CurrentPage}&pageSize={Model.PageSize}";

            var paginatedResult = await HttpService.GetAsync<Paginated<ProductModel>>(url);
            if (paginatedResult != null)
            {
                Model = paginatedResult;
            }

            _loading = false;
        }

        private async Task Previous(int currentPage)
        {
            Model.CurrentPage = currentPage;
            await GetProducts();
        }

        private async Task Next(int currentPage)
        {
            Model.CurrentPage = currentPage;
            await GetProducts();
        }
    }
}
