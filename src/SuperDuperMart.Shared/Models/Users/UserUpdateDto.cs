using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Users
{
    public record UserUpdateDto
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        public string? Role { get; set; }

        public LocationDto Location { get; set; } = new();
    }
}
