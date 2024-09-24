using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PaginatedModel<ProductModel>? Model { get; set; } = new(pageNumber: 1, pageSize: 10);

        private bool _loading = true;

        protected override async Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task GetProducts()
        {
            string? url = $"{Endpoints.Products}?pageNumber={Model?.PageNumber}&pageSize={Model?.PageSize}";

            Model = await HttpService.GetAsync<PaginatedModel<ProductModel>>(url);

            _loading = false;
        }

        private async Task Previous(int pageNumber)
        {
            if (Model != null)
            {
                Model.PageNumber = pageNumber;
                await GetProducts();
            }
        }

        private async Task Page(int pageNumber)
        {
            if (Model != null)
            {
                Model.PageNumber = pageNumber;
            }

            await GetProducts();
        }


        private async Task Next(int pageNumber)
        {
            if (Model != null)
            {
                Model.PageNumber = pageNumber;
                await GetProducts();
            }
        }
    }
}
