using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Products.Components
{
    public partial class ProductCard
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public ProductModel Product { get; set; } = default!;

        public async Task AddToCart()
        {
        }
    }
}
