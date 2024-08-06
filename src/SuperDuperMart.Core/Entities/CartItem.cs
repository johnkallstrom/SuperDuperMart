namespace SuperDuperMart.Core.Entities
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = default!;

        public int CartId { get; set; }
        public Cart Cart { get; set; } = default!;

        public int Quantity { get; set; }
    }
}
