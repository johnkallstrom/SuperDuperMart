namespace SuperDuperMart.Core.Results
{
    public class PaginatedResult<T>
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; } = default!;

        public PaginatedResult()
        {
        }

        public PaginatedResult(bool success, List<string> errors)
        {
            Errors = errors;
        }

        public PaginatedResult(
            bool success,
            int currentPage, 
            int pageSize, 
            int totalPages, 
            IEnumerable<T> data)
        {
            Success = success;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            Data = data;
        }

        public static PaginatedResult<T> Ok(
            int currentPage, 
            int pageSize, 
            int totalPages, 
            IEnumerable<T> data)
        {
            return new PaginatedResult<T>(success: true, currentPage, pageSize, totalPages, data);
        }

        public static PaginatedResult<T> Failure(List<string> errors) => new PaginatedResult<T>(success: false, errors);
    }
}
