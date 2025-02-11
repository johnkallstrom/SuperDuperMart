
namespace SuperDuperMart.Web.Features.Components
{
    public partial class SortableTableHeader
    {
        [Parameter, EditorRequired]
        public string Label { get; set; } = default!;

        [Parameter]
        public EventCallback<string> OnClick { get; set; } = default!;

        private string? SortBy;
        private string? SortOrder;

        protected override void OnParametersSet()
        {
            SortBy = Label;
            SortOrder = "Desc";
        }

        private async Task HandleClick()
        {
            await OnClick.InvokeAsync(SortBy);
        }
    }
}
