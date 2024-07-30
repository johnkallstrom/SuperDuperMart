﻿using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Authentication
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public LoginModel Model { get; set; } = default!;

        private async Task Submit()
        {
            Console.WriteLine(Model.Email);
            Console.WriteLine(Model.Password);
        }
    }
}