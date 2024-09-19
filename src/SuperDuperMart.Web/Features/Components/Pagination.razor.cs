using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Pagination
    {
        [Parameter, EditorRequired]
        public int PageNumber { get; set; }

        [Parameter, EditorRequired]
        public int Pages { get; set; }

        [Parameter]
        public EventCallback<int> OnPreviousClick { get; set; }

        [Parameter]
        public EventCallback<int> OnNextClick { get; set; }

        public int _firstPage { get; set; } = 1;

        private async Task Previous()
        {
            PageNumber -= 1;
            await OnPreviousClick.InvokeAsync(PageNumber);
        }
        private async Task Next()
        {
            PageNumber += 1;
            await OnNextClick.InvokeAsync(PageNumber);
        }
    }
}
