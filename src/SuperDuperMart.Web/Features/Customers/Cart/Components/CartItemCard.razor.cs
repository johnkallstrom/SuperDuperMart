using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Cart.Components
{
    public partial class CartItemCard
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

        [Parameter]
        public EventCallback OnAdd { get; set; }

        [Parameter]
        public EventCallback OnDelete { get; set; }

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public CartItemModel Item { get; set; } = default!;

        private async Task AddCartItem()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;

            int? userId = user.FindUserIdentifier();
            if (userId.HasValue)
            {
                CartModel? cart = await HttpService.GetAsync<CartModel>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Item != null)
                {
                    await HttpService.PostAsync($"{Endpoints.Carts}/{cart.Id}/items/add/{Item.Product.Id}");
                    await OnAdd.InvokeAsync();
                }
            }
        }

        private async Task DeleteCartItem()
        {
            var authState = await AuthenticationStateTask;
            var user = authState.User;

            int? userId = user.FindUserIdentifier();
            if (userId.HasValue)
            {
                CartModel? cart = await HttpService.GetAsync<CartModel>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Item != null)
                {
                    await HttpService.DeleteAsync($"{Endpoints.Carts}/{cart.Id}/items/delete/{Item.Product.Id}");
                    await OnDelete.InvokeAsync();
                }
            }
        }
    }
}
