using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        [Parameter]
        public EventCallback<string> OnSortChange { get; set; } = default!;

        public string SelectedSortBy { get; set; } = default!;

        public List<SelectOption> Options { get; set; } = new();

        protected override void OnInitialized()
        {
            Options = new List<SelectOption>
            {
                new SelectOption("Latest", "Created Desc"),
                new SelectOption("Name (A-Z)", "Name Asc"),
                new SelectOption("Name (Z-A)", "Name Desc"),
                new SelectOption("Price Low", "Price Asc"),
                new SelectOption("Price High", "Price Desc")
            };
        }
    }
}
