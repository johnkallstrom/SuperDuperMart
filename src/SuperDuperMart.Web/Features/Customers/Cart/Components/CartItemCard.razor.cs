using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Cart.Components
{
    public partial class CartItemCard
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public CartItemModel Item { get; set; } = default!;

        private async Task DeleteCartItem()
        {
            int cartId = 1;
            int productId = Item.Product.Id;

            await HttpService.DeleteAsync($"{Endpoints.Carts}/{cartId}/items/delete/{productId}");
        }
    }
}
