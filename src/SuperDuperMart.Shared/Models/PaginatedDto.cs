namespace SuperDuperMart.Shared.Models
{
    public class PaginatedDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public IEnumerable<T> Data { get; set; } = [];

        public PaginatedDto()
        {
        }

        public PaginatedDto(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
