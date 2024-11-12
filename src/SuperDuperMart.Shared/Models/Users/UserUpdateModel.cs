using System.ComponentModel.DataAnnotations;
using SuperDuperMart.Shared.Models.Locations;

namespace SuperDuperMart.Shared.Models.Users
{
    public record UserUpdateModel
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        public string Username { get; set; } = default!;

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = default!;

        public LocationUpdateModel Location { get; set; } = new();

        public int RoleId { get; set; }
    }
}
