namespace SuperDuperMart.Core.Dtos.Users
{
    public record LocationCreateDto
    {
        public string? ZipCode { get; init; }
        public string? StreetName { get; init; }
        public string? City { get; init; }
    }
}
