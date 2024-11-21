namespace SuperDuperMart.Core.Results
{
    public class PagedList<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; } = [];

        public PagedList(IEnumerable<T> data)
        {
            Data = data;
        }

        public PagedList(int totalRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            Data = data;
        }

        public PagedList(
            int pageNumber, 
            int pageSize, 
            int totalPages, 
            int totalRecords,
            IEnumerable<T> data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
            Data = data;
        }
    }
}
