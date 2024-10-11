namespace SuperDuperMart.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public string Avatar { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public List<string> Roles { get; set; } = [];

        public Location Location { get; set; } = default!;
        public Cart Cart { get; set; } = default!;
    }
}
