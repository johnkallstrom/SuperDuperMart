namespace SuperDuperMart.Core.Interfaces
{
    public interface IQueryParams
    {
        public string? SortBy { get; set; }
        public string? SortOrder { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
