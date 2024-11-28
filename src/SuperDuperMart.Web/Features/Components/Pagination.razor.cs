using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Enums;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Pagination
    {
        [Parameter, EditorRequired]
        public int PageNumber { get; set; } = 1;

        [Parameter, EditorRequired]
        public int TotalPages { get; set; }

        [Parameter]
        public Position Position { get; set; }

        [Parameter]
        public EventCallback<int> OnPreviousClick { get; set; }

        [Parameter]
        public EventCallback<int> OnNextClick { get; set; }

        public string NavCssClasses { get; set; } = "d-flex flex-column";

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

        protected override void OnInitialized()
        {
            switch (Position)
            {
                case Position.Start:
                    NavCssClasses = $"{NavCssClasses} align-items-start";
                    break;
                case Position.Center:
                    NavCssClasses = $"{NavCssClasses} align-items-center";
                    break;
                case Position.End:
                    NavCssClasses = $"{NavCssClasses} align-items-end";
                    break;
            }
        }
    }
}
