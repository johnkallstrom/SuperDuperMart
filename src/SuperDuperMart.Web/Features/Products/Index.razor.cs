using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Products
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public IEnumerable<ProductModel> Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            var products = await HttpService.GetAsync<IEnumerable<ProductModel>>("/products");
            if (products != null)
            {
                Model = products;
            }
        }
    }
}
