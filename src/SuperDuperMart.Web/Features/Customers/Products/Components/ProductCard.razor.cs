using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Products.Components
{
    public partial class ProductCard
    {
        [Parameter, EditorRequired]
        public ProductModel Product { get; set; } = default!;
    }
}
