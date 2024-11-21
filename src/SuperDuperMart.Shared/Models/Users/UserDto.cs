namespace SuperDuperMart.Shared.Models.Users
{
    public record UserDto
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;

        public RoleDto? Role { get; set; }
        public LocationDto? Location { get; set; }
    }
}
