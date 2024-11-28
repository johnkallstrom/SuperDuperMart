using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        [Parameter]
        public EventCallback<string> OnSortByChange { get; set; } = default!;

        public string SortBy { get; set; } = default!;

        public List<string> Options { get; set; } = ["Created", "Name", "Price"];

        private async void HandleSortByChange(ChangeEventArgs args)
        {
            string? value = args.Value?.ToString();
            await OnSortByChange.InvokeAsync(value);
        }
    }
}
