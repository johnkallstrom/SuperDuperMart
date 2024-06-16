namespace SuperDuperMart.Api.Models
{
    public record LocationResponse
    {
        public required string ZipCode { get; init; }
        public required string StreetName { get; init; }
        public required string City { get; init; }
    }
}
