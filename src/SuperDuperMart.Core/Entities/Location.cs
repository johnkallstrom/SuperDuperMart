namespace SuperDuperMart.Core.Entities
{
    public class Location : BaseEntity
    {
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
