using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Products.Components
{
    public partial class ProductCard
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public ProductModel Product { get; set; } = default!;

        private bool _loading = false;

        private async Task AddToCart()
        {
            _loading = true;

            var authState = await AuthenticationStateTask;
            var user = authState.User;

            int? userId = user.FindUserIdentifier();
            if (userId.HasValue)
            {
                CartModel? cart = await HttpService.GetAsync<CartModel>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Product != null)
                {
                    await HttpService.PostAsync($"{Endpoints.Carts}/{cart.Id}/items/add/{Product.Id}");
                }
            }

            _loading = false;
        }
    }
}
