using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Collapse
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
    }
}
