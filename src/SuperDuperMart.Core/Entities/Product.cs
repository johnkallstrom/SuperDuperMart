namespace SuperDuperMart.Core.Entities
{
    public class Product : BaseEntity
    {
        public string? Image { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required string Material { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; } = default!;

        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}