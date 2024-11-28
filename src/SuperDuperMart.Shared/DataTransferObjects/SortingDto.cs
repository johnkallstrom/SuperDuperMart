namespace SuperDuperMart.Shared.DataTransferObjects
{
    public class SortingDto
    {
        public string SortBy { get; set; } = default!;
        public string SortOrder { get; set; } = default!;

        public SortingDto()
        {
        }

        public SortingDto(string sortBy, string sortOrder)
        {
            SortBy = sortBy;
            SortOrder = sortOrder;
        }
    }
}
