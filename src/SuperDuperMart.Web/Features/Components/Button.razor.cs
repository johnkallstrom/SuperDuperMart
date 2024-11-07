using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Button
    {
        [Parameter]
        public Icon Icon { get; set; }

        [Parameter, EditorRequired]
        public string Label { get; set; } = default!;

        [Parameter]
        public EventCallback OnClick { get; set; }

        [Parameter]
        public ButtonType Type { get; set; }

        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        [Parameter]
        public bool Loading { get; set; }

        private async Task Click() => await OnClick.InvokeAsync();
    }
}
