namespace SuperDuperMart.Core.Entities
{
    public class User : IdentityUser<int>
    {
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public Location Location { get; set; } = default!;
        public Cart Cart { get; set; } = default!;
    }
}
