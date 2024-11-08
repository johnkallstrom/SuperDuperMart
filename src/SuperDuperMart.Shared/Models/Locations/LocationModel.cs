namespace SuperDuperMart.Shared.Models.Locations
{
    public record LocationModel
    {
        public required string ZipCode { get; init; }
        public required string StreetName { get; init; }
        public required string City { get; init; }
    }
}
