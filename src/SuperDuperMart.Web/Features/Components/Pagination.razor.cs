using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Pagination
    {
        [Parameter, EditorRequired]
        public EventCallback<int> OnPreviousClick { get; set; }

        [Parameter, EditorRequired]
        public EventCallback<int> OnNextClick { get; set; }

        private int _currentPage = 1;

        private async Task Previous()
        {
            _currentPage -= 1;
            await OnPreviousClick.InvokeAsync(_currentPage);
        }
        private async Task Next()
        {
            _currentPage += 1;
            await OnNextClick.InvokeAsync(_currentPage);
        }
    }
}
