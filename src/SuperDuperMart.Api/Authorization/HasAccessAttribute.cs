using Microsoft.AspNetCore.Mvc.Filters;

namespace SuperDuperMart.Api.Authorization
{
    public class HasAccessAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["User"] as UserModel;
            if (user == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
