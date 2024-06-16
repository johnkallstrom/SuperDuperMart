using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Api.Models
{
    public record ProductCreateRequest
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; init; } = default!;

        public string? Description { get; init; }

        [Required(ErrorMessage = "Please enter a price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Please enter a material")]
        public string Material { get; init; } = default!;
    }
}
