namespace SuperDuperMart.Web.Features.Components
{
    public partial class Navigation
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private readonly string _redirectUrl = "/";

        private async Task HandleLogout()
        {
            await AuthenticationService.EndUserSessionAsync();
            NavigationManager.NavigateTo(_redirectUrl);
        }
    }
}
