using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.DataTransferObjects.Carts;

namespace SuperDuperMart.Web.Features.Members.Carts.Components
{
    public partial class CartItemCard
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public EventCallback OnDelete { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public CartItemDto Item { get; set; } = default!;

        private async Task AddCartItem()
        {
            var user = await AuthenticationService.GetCurrentUserAsync();
            int? userId = user.FindUserIdentifier();

            if (userId.HasValue)
            {
                CartDto? cart = await HttpService.GetAsync<CartDto>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Item != null)
                {
                    await HttpService.PostAsync($"{Endpoints.Carts}/{cart.Id}/items/add/{Item.Product.Id}");
                    await OnAdd.InvokeAsync();
                }
            }
        }

        private async Task DeleteCartItem()
        {
            var user = await AuthenticationService.GetCurrentUserAsync();
            int? userId = user.FindUserIdentifier();

            if (userId.HasValue)
            {
                CartDto? cart = await HttpService.GetAsync<CartDto>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Item != null)
                {
                    await HttpService.DeleteAsync($"{Endpoints.Carts}/{cart.Id}/items/delete/{Item.Product.Id}");
                    await OnDelete.InvokeAsync();
                }
            }
        }
    }
}
