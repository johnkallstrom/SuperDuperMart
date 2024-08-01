using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Enums;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Button
    {
        [Parameter, EditorRequired]
        public string Label { get; set; } = default!;

        [Parameter, EditorRequired]
        public ButtonType Type { get; set; }

        [Parameter]
        public Color Color { get; set; } = Color.Primary;

        [Parameter]
        public bool Loading { get; set; }
    }
}
