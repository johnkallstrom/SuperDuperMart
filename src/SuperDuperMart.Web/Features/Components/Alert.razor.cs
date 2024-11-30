using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Alert
    {
        [Parameter, EditorRequired]
        public string Message { get; set; } = default!;

        [Parameter]
        public Color Color { get; set; }
    }
}
