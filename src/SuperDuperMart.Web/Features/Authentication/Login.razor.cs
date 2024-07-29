using Microsoft.AspNetCore.Components;
using SuperDuperMart.Web.Http;

namespace SuperDuperMart.Web.Features.Authentication
{
    public partial class Login
    {
        [Inject]
        public IHttpService HttpService { get; set; } = default!;
    }
}
