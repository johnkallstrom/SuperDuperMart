namespace SuperDuperMart.Core.Interfaces
{
    public interface IQueryParams
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
