using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components.Toasts
{
    public partial class ErrorToast
    {
        [Parameter]
        public string Message { get; set; } = default!;
    }
}
