namespace SuperDuperMart.Core.Models
{
    public record UserModel
    {
        public int Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public string? Username { get; init; }
        public required string Email { get; init; }

        public LocationModel? Location { get; init; }
    }
}
