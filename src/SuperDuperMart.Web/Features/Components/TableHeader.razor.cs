
namespace SuperDuperMart.Web.Features.Components
{
    public partial class TableHeader
    {
        [Parameter, EditorRequired]
        public string Label { get; set; } = default!;

        [Parameter]
        public EventCallback<string> OnClick { get; set; } = default!;

        private string? SortBy;

        protected override void OnParametersSet()
        {
            SortBy = Label;
        }
    }
}
