using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Rendering;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        [Parameter]
        public EventCallback<string> OnSortChange { get; set; } = default!;

        public string SelectedSortBy { get; set; } = default!;

        public List<SelectSortOption> Options { get; set; } = new();

        protected override void OnInitialized()
        {
            Options = new List<SelectSortOption>
            {
                new SelectSortOption("Latest", "Created", SortOrder.Descending),
                new SelectSortOption("Name (A-Z)", "Name", SortOrder.Ascending),
                new SelectSortOption("Name (Z-A)", "Name", SortOrder.Descending),
                new SelectSortOption("Price Low", "Price", SortOrder.Ascending),
                new SelectSortOption("Price High", "Price", SortOrder.Descending),
            };
        }
    }
}
