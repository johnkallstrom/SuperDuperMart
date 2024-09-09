namespace SuperDuperMart.Shared.Models
{
    public class Paginated<TModel>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TModel>? Data { get; set; }

        public Paginated(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
