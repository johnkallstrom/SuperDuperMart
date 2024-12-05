namespace SuperDuperMart.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string? Avatar { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateOnly Birthday { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public Location Location { get; set; } = default!;
        public Cart Cart { get; set; } = default!;
    }
}
