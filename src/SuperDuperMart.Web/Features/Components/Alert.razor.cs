using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Alert
    {
        [Parameter, EditorRequired]
        public bool Display { get; set; }

        [Parameter, EditorRequired]
        public string Message { get; set; } = default!;

        [Parameter]
        public EventCallback OnCloseButtonClick { get; set; }

        private async Task Close() => await OnCloseButtonClick.InvokeAsync();
    }
}
