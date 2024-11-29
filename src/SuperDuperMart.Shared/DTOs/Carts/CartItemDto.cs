using SuperDuperMart.Shared.DTOs.Products;

namespace SuperDuperMart.Shared.DTOs.Carts
{
    public class CartItemDto
    {
        public ProductDto Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
