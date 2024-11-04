using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Cart.Components
{
    public partial class CartItemCard
    {
        [Parameter, EditorRequired]
        public CartItemModel Item { get; set; } = default!;
    }
}
