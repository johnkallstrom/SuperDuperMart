namespace SuperDuperMart.Core.Models.Users
{
    public record UserDto
    {
        public int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? Username { get; init; }
        public required string Email { get; init; }

        public LocationDto? Location { get; init; }
    }
}
