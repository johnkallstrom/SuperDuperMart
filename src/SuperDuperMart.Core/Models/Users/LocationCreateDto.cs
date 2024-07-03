namespace SuperDuperMart.Core.Models.Users
{
    public record LocationCreateDto
    {
        public string? ZipCode { get; init; }
        public string? StreetName { get; init; }
        public string? City { get; init; }
    }
}
