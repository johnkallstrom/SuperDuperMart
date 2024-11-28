using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Rendering;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Button
    {
        [Parameter]
        public string Label { get; set; } = default!;

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public ButtonType Type { get; set; }

        [Parameter]
        public ButtonSize Size { get; set; } = ButtonSize.Default;

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public Icon Icon { get; set; } = Icon.None;

        [Parameter]
        public EventCallback OnClick { get; set; }

        private async Task Click() => await OnClick.InvokeAsync();

        private bool _disabled = false;

        protected override void OnParametersSet()
        {
            _disabled = Loading;
        }
    }
}
