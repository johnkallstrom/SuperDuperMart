namespace SuperDuperMart.Shared.Models.Products
{
    public record ProductDto
    {
        public int Id { get; init; }
        public string? Image { get; set; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required decimal Price { get; init; }
        public required string Material { get; init; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
