namespace SuperDuperMart.Shared.Models.Users
{
    public record UserUpdateModel
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Username { get; set; }
        public string? Email { get; set; }

        public LocationUpdateModel Location { get; set; } = new();
    }
}
