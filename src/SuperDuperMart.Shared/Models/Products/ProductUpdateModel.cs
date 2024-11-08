using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Products
{
    public record ProductUpdateModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a material")]
        public string Material { get; set; } = default!;
    }
}
