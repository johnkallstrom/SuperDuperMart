using Blazored.Toast;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Carts;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Members.Products.Components
{
    public partial class ProductCard
    {
        [Inject]
        public IAuthenticationService AuthenticationService { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter, EditorRequired]
        public ProductDto Product { get; set; } = default!;

        private bool Loading = false;

        private async Task AddProductToCart()
        {
            Loading = true;

            var user = await AuthenticationService.GetCurrentUserAsync();

            int? userId = user.FindUserIdentifier();
            if (userId.HasValue)
            {
                CartDto? cart = await HttpService.GetAsync<CartDto>($"{Endpoints.Carts}/user/{userId.Value}");
                if (cart != null && Product != null)
                {
                    await HttpService.PostAsync($"{Endpoints.Carts}/{cart.Id}/items/add/{Product.Id}");

                    var parameters = new ToastParameters();
                    parameters.Add(nameof(InfoToast.Message), $"{Product.Name} added");

                    ToastService.ShowToast<InfoToast>(parameters);
                }
            }

            Loading = false;
        }
    }
}
