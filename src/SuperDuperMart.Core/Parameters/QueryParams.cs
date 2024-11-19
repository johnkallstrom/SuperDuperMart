namespace SuperDuperMart.Core.Parameters
{
    public class QueryParams : IQueryParams
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
