namespace SuperDuperMart.Shared.Models.Products
{
    public record ProductModel
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required decimal Price { get; init; }
        public required string Material { get; init; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
