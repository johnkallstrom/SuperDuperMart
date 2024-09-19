namespace SuperDuperMart.Shared.Models
{
    public class PaginatedModel<TModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Pages { get; set; }
        public IEnumerable<TModel> Data { get; set; } = [];

        public PaginatedModel()
        {
        }

        public PaginatedModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
