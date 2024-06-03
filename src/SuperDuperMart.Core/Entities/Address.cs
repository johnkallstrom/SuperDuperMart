namespace SuperDuperMart.Core.Entities
{
    public class Address : BaseEntity
    {
        public required string ZipCode { get; set; }
        public required string StreetName { get; set; }
        public required string City { get; set; }

        public int CustomerId { get; set; }
        public User Customer { get; set; } = default!;
    }
}
