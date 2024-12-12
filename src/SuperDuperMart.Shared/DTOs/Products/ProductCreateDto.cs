﻿using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.DTOs.Products
{
    public record ProductCreateDto
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }

        [Required(ErrorMessage = "Please enter a price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a material")]
        public string Material { get; set; } = default!;

        [Required(ErrorMessage = "Please choose a category")]
        public int CategoryId { get; set; }
    }
}
