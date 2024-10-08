﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Web.Features.Customers.Cart
{
    public partial class Index
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool _loading = true;
        public CartModel? Model { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await GetCart();
        }

        private async Task GetCart()
        {
            var authState = await AuthenticationStateTask;
            var principal = authState.User;

            int? userId = principal.FindUserIdentifier();
            if (userId.HasValue)
            {
                Model = await HttpService.GetAsync<CartModel>($"{Endpoints.Carts}/user/{userId}?includeItems=true");
                _loading = false;
            }
        }
    }
}
