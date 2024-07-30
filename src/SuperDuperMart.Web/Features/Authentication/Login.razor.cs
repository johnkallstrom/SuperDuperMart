using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models.Users;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Authentication
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        public LoginModel Model { get; set; } = new();

        private async Task Submit()
        {
            Console.WriteLine($"Email: {Model.Email}");
            Console.WriteLine($"Password: {Model.Password}");
            Console.WriteLine($"Is Admin: {Model.IsAdministrator}");
        }
    }
}
