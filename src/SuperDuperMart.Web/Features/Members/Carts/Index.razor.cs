using Blazored.Toast;
using Blazored.Toast.Services;
using SuperDuperMart.Web.Features.Components.Toasts;

namespace SuperDuperMart.Web.Features.Members.Carts
{
    public partial class Index
    {
        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        [Parameter]
        public int UserId { get; set; }

        private bool Loading = true;
        public CartDto Dto { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetCart();
        }

        private async Task GetCart()
        {
            CartDto? cart = await HttpService.GetAsync<CartDto>($"{Endpoints.Carts}/user/{UserId}?includeItems=true");
            if (cart is null)
            {
                var parameters = new ToastParameters();
                parameters.Add(nameof(ErrorToast.Message), "Something went wrong");

                ToastService.ShowToast<ErrorToast>(parameters);
            }
            else
            {
                Dto = cart;
            }

            Loading = false;
        }
    }
}
