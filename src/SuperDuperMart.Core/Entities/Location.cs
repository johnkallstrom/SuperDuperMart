namespace SuperDuperMart.Core.Entities
{
    public class Location : BaseEntity
    {
        public required string ZipCode { get; set; }
        public required string StreetName { get; set; }
        public required string City { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
