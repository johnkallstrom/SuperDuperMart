using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Pagination
    {
        [Parameter, EditorRequired]
        public int PageNumber { get; set; }

        [Parameter, EditorRequired]
        public int TotalPages { get; set; }

        [Parameter]
        public EventCallback<int> OnPreviousClick { get; set; }

        [Parameter]
        public EventCallback<int> OnPageClick { get; set; }

        [Parameter]
        public EventCallback<int> OnNextClick { get; set; }

        public bool DisablePrevious
        {
            get
            {
                return PageNumber <= 1;
            }
        }

        public bool DisableNext
        {
            get
            {
                return PageNumber >= TotalPages;
            }
        }
    }
}
