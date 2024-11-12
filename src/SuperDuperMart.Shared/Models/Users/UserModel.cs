using SuperDuperMart.Shared.Models.Locations;

namespace SuperDuperMart.Shared.Models.Users
{
    public record UserModel
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Role { get; set; }

        public LocationModel? Location { get; set; }
    }
}
