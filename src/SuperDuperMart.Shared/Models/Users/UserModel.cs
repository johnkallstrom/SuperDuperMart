namespace SuperDuperMart.Shared.Models.Users
{
    public record UserModel
    {
        public int Id { get; init; }
        public string? Avatar { get; set; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? Username { get; init; }
        public required string Email { get; init; }

        public LocationModel? Location { get; init; }
        public List<string> Roles { get; set; } = default!;
    }
}
