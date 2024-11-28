using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DataTransferObjects;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IProductHttpService ProductHttpService { get; set; } = default!;

        private bool Loading = true;

        public PagedListDto<ProductDto> Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Model = await ProductHttpService.GetAsync();
            Loading = false;
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            Model = await ProductHttpService.GetAsync(Model.PageNumber);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;
            Model = await ProductHttpService.GetAsync(Model.PageNumber);
        }
    }
}
