namespace SuperDuperMart.Web.Rendering
{
    public class SelectOption : SelectOptionBase
    {
        public SortOrderType Order { get; set; }

        public SelectOption(string text, string value) : base(text, value)
        {
        }

        public SelectOption(string text, string value, SortOrderType order) : base(text, $"{value} {order}")
        {
            Order = order;
        }
    }
}
