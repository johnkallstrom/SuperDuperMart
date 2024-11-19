namespace SuperDuperMart.Core.Results
{
    public class Result<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; } = [];

        public Result(IEnumerable<T> data)
        {
            Data = data;
        }

        public Result(int totalRecords, IEnumerable<T> data)
        {
            TotalRecords = totalRecords;
            Data = data;
        }

        public Result(
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
