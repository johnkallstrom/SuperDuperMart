namespace SuperDuperMart.Api.Parameters
{
    public class ProductQueryParams : IQueryParams
    {
        public string? SearchTerm { get; set; }
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
}
