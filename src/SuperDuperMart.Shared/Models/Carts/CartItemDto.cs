using SuperDuperMart.Shared.Models.Products;

namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartItemDto
    {
        public ProductDto Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
