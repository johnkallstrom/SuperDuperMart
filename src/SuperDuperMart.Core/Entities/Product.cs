namespace SuperDuperMart.Core.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required string Material { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}