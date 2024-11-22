using SuperDuperMart.Shared.DataTransferObjects.Products;

namespace SuperDuperMart.Shared.DataTransferObjects.Carts
{
    public class CartItemDto
    {
        public ProductDto Product { get; set; } = default!;
        public int Quantity { get; set; }
    }
}
