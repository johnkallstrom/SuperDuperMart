namespace SuperDuperMart.Web.Rendering
{
    public class SelectOption : SelectOptionBase
    {
        public SortOrder Order { get; set; }

        public SelectOption(string text, string value) : base(text, value)
        {
        }

        public SelectOption(string text, string value, SortOrder order) : base(text, $"{value} {order}")
        {
            Order = order;
        }
    }
}
