namespace SuperDuperMart.Web.Features.Components
{
    public partial class SortDropdown
    {
        [Parameter, EditorRequired]
        public List<SelectOption> Options { get; set; } = default!;

        [Parameter]
        public EventCallback<(string SortBy, SortOrderType SortOrderType)> OnSelection { get; set; } = default!;

        public string SelectedOption { get; set; } = default!;

        private async Task HandleSelection(ChangeEventArgs args)
        {
            string? value = args.Value?.ToString();
            if (!string.IsNullOrWhiteSpace(value))
            {
                string[] words = value.Split(' ');
                string sortBy = words.First();
                SortOrderType sortOrderType = default;

                if (words.Count() > 0)
                {
                    foreach (var word in words)
                    {
                        if (Enum.TryParse(word, out SortOrderType result))
                        {
                            sortOrderType = result;
                        }
                    }
                }

                await OnSelection.InvokeAsync((sortBy, sortOrderType));
            }
        }
    }
}
