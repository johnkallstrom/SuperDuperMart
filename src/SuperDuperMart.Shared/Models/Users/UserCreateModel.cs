using System.ComponentModel.DataAnnotations;

namespace SuperDuperMart.Shared.Models.Users
{
    public record UserCreateModel
    {

        [Required(ErrorMessage = "Please enter a username")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "Please enter a valid confirm password")]
        [Compare("Password", ErrorMessage = "Please provide matching passwords")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = default!;
    }
}
