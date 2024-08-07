namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartItemModel
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
