namespace SuperDuperMart.Shared.Models.Users
{
    public record LocationUpdateModel
    {
        public string? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? City { get; set; }
    }
}
