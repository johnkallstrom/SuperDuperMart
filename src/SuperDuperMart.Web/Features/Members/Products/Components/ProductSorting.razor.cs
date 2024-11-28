using SuperDuperMart.Shared.DataTransferObjects;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductSorting
    {
        public SortingDto Model { get; set; } = new(sortBy: "Created", sortOrder: "Desc");
    }
}
