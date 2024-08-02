using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class SuperAlert
    {
        [Parameter, EditorRequired]
        public string Message { get; set; } = "Empty.";

        [Parameter, EditorRequired]
        public EventCallback OnCloseButtonClick { get; set; }

        [Parameter]
        public Color Color { get; set; } = Color.Light;

        private async Task Close() => await OnCloseButtonClick.InvokeAsync();
    }
}
