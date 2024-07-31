using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Carts
{
    public partial class Index
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int UserId { get; set; }

        public CartModel? Model { get; set; } = default!;
        public bool Loading { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Loading = true;
            await GetCart();
            Loading = false;
        }

        private async Task GetCart()
        {
            Model = await HttpService.GetAsync<CartModel>($"{Endpoints.Carts}/user/{UserId}");
        }
    }
}
