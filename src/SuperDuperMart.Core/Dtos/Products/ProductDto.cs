namespace SuperDuperMart.Core.Dtos.Products
{
    public record ProductDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public required decimal Price { get; init; }
        public required string Material { get; init; }
    }
}
