using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DataTransferObjects.Carts;

namespace SuperDuperMart.Web.Features.Members.Carts
{
    public partial class Index
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool _loading = true;
        public CartDto? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetCart();
        }

        private async Task GetCart()
        {
            var user = await AuthenticationService.GetCurrentUserAsync();
            int? userId = user.FindUserIdentifier();

            if (userId.HasValue)
            {
                Model = await HttpService.GetAsync<CartDto>($"{Endpoints.Carts}/user/{userId}?includeItems=true");
                _loading = false;
            }
        }
    }
}
