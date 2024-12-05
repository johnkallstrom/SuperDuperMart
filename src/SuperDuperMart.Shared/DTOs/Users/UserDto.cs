namespace SuperDuperMart.Shared.DTOs.Users
{
    public record UserDto
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateOnly Birthday { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public RoleDto? Role { get; set; }
        public LocationDto? Location { get; set; }
    }
}
