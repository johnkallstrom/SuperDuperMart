namespace SuperDuperMart.Core.Identity
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Location Location { get; set; } = default!;
    }
}
