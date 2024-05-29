using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public required string Material { get; set; }
    }
}