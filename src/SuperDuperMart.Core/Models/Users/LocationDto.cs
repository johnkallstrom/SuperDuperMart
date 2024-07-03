namespace SuperDuperMart.Core.Models.Users
{
    public record LocationDto
    {
        public required string ZipCode { get; init; }
        public required string StreetName { get; init; }
        public required string City { get; init; }
    }
}
