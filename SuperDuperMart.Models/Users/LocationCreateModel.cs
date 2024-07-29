namespace SuperDuperMart.Models.Users
{
    public record LocationCreateModel
    {
        public string? ZipCode { get; init; }
        public string? StreetName { get; init; }
        public string? City { get; init; }
    }
}
