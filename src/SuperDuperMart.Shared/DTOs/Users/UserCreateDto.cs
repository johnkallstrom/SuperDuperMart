using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.DTOs.Users
{
    public record UserCreateDto
    {

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please enter valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Please enter valid confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Please provide matching passwords")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = default!;

        [Required(ErrorMessage = "Please choose a role")]
        public int RoleId { get; set; } = 1;
    }
}
