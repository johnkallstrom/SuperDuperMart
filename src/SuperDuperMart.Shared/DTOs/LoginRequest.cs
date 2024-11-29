using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.DTOs
{
    public record LoginRequest
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
