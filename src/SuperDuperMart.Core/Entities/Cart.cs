namespace SuperDuperMart.Core.Entities
{
    public class Cart : BaseEntity
    {
        public bool Purchased { get; set; }
        public decimal TotalCost { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}
