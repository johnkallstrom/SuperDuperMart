
namespace SuperDuperMart.Web.Features.Components
{
    public partial class SortableTableHeader
    {
        [Parameter, EditorRequired]
        public string Label { get; set; } = default!;

        [Parameter]
        public string SortBy { get; set; } = default!;

        [Parameter]
        public string SortOrder { get; set; } = default!;

        [Parameter, EditorRequired]
        public EventCallback<(string SortBy, string SortOrder)> OnClick { get; set; }

        public Icon Icon { get; set; }

        protected override void OnParametersSet()
        {
            Icon = SortOrder is "Desc" ? Icon.CaretDown : Icon.CaretUp;
        }

        private async Task HandleClick()
        {
            SortOrder = SortOrder is "Desc" ? "Asc" : "Desc";
            Icon = SortOrder is "Desc" ? Icon.CaretDown : Icon.CaretUp;

            await OnClick.InvokeAsync((SortBy, SortOrder));
        }
    }
}
