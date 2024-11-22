namespace SuperDuperMart.Shared.DataTransferObjects.Users
{
    public class LocationDto
    {
        public string ZipCode { get; set; } = default!;
        public string StreetName { get; set; } = default!;
        public string City { get; set; } = default!;
    }
}
