namespace SuperDuperMart.Shared.Models.Carts
{
    public class CartDto
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public bool Purchased { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
        public List<CartItemDto> Items { get; set; } = new();
    }
}
