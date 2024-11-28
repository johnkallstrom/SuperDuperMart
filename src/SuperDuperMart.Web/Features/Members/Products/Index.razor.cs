using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IProductHttpService ProductHttpService { get; set; } = default!;

        private bool Loading = true;

        public string SortBy { get; set; } = "Created";
        public string SortOrder { get; set; } = "Desc";

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model = await ProductHttpService.GetAsync(SortBy, SortOrder);
            Loading = false;
        }

        private async Task HandleSortChange(string value)
        {
            SortBy = value.Split(' ').First();
            SortOrder = value.Split(' ').Last();

            Model = await ProductHttpService.GetAsync(Model.PageNumber, SortBy, SortOrder);
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            Model = await ProductHttpService.GetAsync(Model.PageNumber, SortBy, SortOrder);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            Model = await ProductHttpService.GetAsync(Model.PageNumber, SortBy, SortOrder);
        }
    }
}
