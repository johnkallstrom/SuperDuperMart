namespace SuperDuperMart.Web.Features.Components
{
    public partial class Layout
    {
        private ErrorBoundary? errorBoundary;

        protected override void OnParametersSet()
        {
            errorBoundary?.Recover();
        }
    }
}
