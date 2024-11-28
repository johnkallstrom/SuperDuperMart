using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Features.Members.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IProductHttpService ProductHttpService { get; set; } = default!;

        private bool Loading = true;

        public string SortBy { get; set; } = "Created";
        public string SortOrder { get; set; } = "Desc";

        public PagedListDto<ProductDto> Model { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Model.PageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            Model.PageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");


            Model = await ProductHttpService.GetAsync(
                Model.PageNumber, 
                Model.PageSize, 
                SortBy, 
                SortOrder);

            Loading = false;
        }

        private async Task HandleSortChange(string value)
        {
            SortBy = value.Split(' ').First();
            SortOrder = value.Split(' ').Last();

            Model = await ProductHttpService.GetAsync(
                Model.PageNumber, 
                Model.PageSize, 
                SortBy, 
                SortOrder);
        }

        private async Task HandlePreviousClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;

            Model = await ProductHttpService.GetAsync(
                Model.PageNumber, 
                Model.PageSize, 
                SortBy, 
                SortOrder);
        }

        private async Task HandleNextClick(int pageNumber)
        {
            Model.PageNumber = pageNumber;

            Model = await ProductHttpService.GetAsync(
                Model.PageNumber, 
                Model.PageSize, 
                SortBy, 
                SortOrder);
        }
    }
}
