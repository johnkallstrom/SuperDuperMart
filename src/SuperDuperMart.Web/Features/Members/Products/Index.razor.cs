using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IProductHttpService ProductHttpService { get; set; } = default!;

        private bool Loading = true;

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model = await ProductHttpService.GetAsync();
            Loading = false;
        }

        private async Task HandleSortByChange(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                string[] words = value.Split(' ');

                string sortBy = words[0];
                string sortOrder = words[1];

                Console.WriteLine(sortBy);
                Console.WriteLine(sortOrder);
            }
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
