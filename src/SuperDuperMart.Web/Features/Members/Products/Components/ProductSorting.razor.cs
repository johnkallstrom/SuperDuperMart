using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        [Parameter]
        public EventCallback<(string SortBy, string SortOrder)> OnSortChange { get; set; } = default!;

        public string SelectedSortOption { get; set; } = default!;

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

        private async Task HandleSortChange(ChangeEventArgs args)
        {
            string? value = args.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string[] words = value.Split(' ');

                if (words.Count() > 0)
                {
                    string sortBy = words.First();
                    string sortOrder = words.Last();

                    await OnSortChange.InvokeAsync((sortBy, sortOrder));
                }
            }
        }
    }
}
