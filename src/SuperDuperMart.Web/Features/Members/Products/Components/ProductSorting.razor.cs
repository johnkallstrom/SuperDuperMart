namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        public string SortBy { get; set; } = default!;

        public List<string> Options { get; set; } = new List<string>
        {
            { "Latest" },
            { "Price" },
            { "Name" },
        };
    }
}
