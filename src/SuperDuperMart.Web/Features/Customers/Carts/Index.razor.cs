using Microsoft.AspNetCore.Components;

namespace SuperDuperMart.Web.Features.Customers.Carts
{
    public partial class Index
    {
        [Parameter]
        public int UserId { get; set; }
    }
}
