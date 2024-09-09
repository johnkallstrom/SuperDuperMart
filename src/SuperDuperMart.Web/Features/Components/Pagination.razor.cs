using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Pagination
    {
        [Parameter, EditorRequired]
        public int CurrentPage { get; set; }

        [Parameter, EditorRequired]
        public int TotalPages { get; set; }

        [Parameter]
        public EventCallback<int> OnPreviousClick { get; set; }

        [Parameter]
        public EventCallback<int> OnNextClick { get; set; }

        public int _firstPage { get; set; } = 1;

        private async Task Previous()
        {
            CurrentPage -= 1;
            await OnPreviousClick.InvokeAsync(CurrentPage);
        }
        private async Task Next()
        {
            CurrentPage += 1;
            await OnNextClick.InvokeAsync(CurrentPage);
        }
    }
}
