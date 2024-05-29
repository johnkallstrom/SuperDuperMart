namespace SuperDuperMart.Core.Entities
{
    public class Customer : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? Username { get; set; }
        public required string Email { get; set; }

        public Address Address { get; set; } = default!;
    }
}
