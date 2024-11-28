namespace SuperDuperMart.Web.Rendering
{
    public class SelectSortOption : SelectOptionBase
    {
        public SortOrder Order { get; set; }

        public SelectSortOption(string text, string value) : base(text, value)
        {
        }

        public SelectSortOption(string text, string value, SortOrder order) : base(text, value)
        {
            Order = order;
        }
    }
}
