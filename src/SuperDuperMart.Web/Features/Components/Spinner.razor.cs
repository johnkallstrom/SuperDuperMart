using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Components
{
    public partial class Spinner
    {
        /// <summary>
        /// Flag used to show or hide the spinner
        /// </summary>
        [Parameter, EditorRequired]
        public bool Enable { get; set; }
    }
}
