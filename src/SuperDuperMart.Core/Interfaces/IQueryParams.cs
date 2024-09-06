namespace SuperDuperMart.Core.Interfaces
{
    public interface IQueryParams
    {
        public string? SearchTerm { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
}
