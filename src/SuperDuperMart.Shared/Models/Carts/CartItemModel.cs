using SuperDuperMart.Shared.Models.Products;

namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartItemModel
    {
        public ProductModel Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
