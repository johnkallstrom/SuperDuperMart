using Microsoft.AspNetCore.Mvc.Filters;

namespace SuperDuperMart.Api.Filters
{
    /// <summary>
    /// Determines if the provided password and confirm password is a match
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ConfirmPassword : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            UserCreateDto? model = null;

            if (context.ActionArguments.TryGetValue("dto", out object? value))
            {
                model = value as UserCreateDto;
            }

            if (model != null)
            {
                if (!model.Password.Equals(model.ConfirmPassword))
                {
                    context.Result = new BadRequestObjectResult(new { Error = "The password and confirm password do not match"});
                    return;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
