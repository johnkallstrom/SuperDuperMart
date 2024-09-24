using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features.Administrators.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public PaginatedModel<ProductModel> Model { get; set; } = new(pageNumber: 1, pageSize: 10);

        private bool _loading = true;
        private int[] _pageSizeOptions = [10, 25, 50, 75, 100];

        protected override async Task OnInitializedAsync()
        {
            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task GetProducts(int pageNumber, int pageSize)
        {
            string? url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}";

            var data = await HttpService.GetAsync<PaginatedModel<ProductModel>>(url);
            if (data != null)
            {
                Model = data;
            }

            _loading = false;
        }

        private async Task HandlePageSizeSelection(int pageSize)
        {
            Model.PageSize = pageSize;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task HandlePageClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }


        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            await GetProducts(Model.PageNumber, Model.PageSize);
        }
    }
}
