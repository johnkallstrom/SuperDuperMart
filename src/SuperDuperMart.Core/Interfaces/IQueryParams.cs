namespace SuperDuperMart.Core.Interfaces
{
    public interface IQueryParams
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
    }
}
