namespace SuperDuperMart.Shared.Models
{
    public class PaginatedModel<T> where T : class
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; } = default!;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; } = default!;
    }
}
