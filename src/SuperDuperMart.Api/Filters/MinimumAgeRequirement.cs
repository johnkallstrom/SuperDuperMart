using Microsoft.AspNetCore.Mvc.Filters;

namespace SuperDuperMart.Api.Filters
{
    public class MinimumAgeRequirement : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            UserCreateDto? dto = null;

            if (context.ActionArguments.TryGetValue("dto", out object? value))
            {
                dto = value as UserCreateDto;
            }

            if (dto != null)
            {
                var birthday = dto.Birthday;
                var today = DateTime.Now;

                int age = today.Year - birthday.Year;

                if (age < 21)
                {
                    context.Result = new BadRequestObjectResult(new { Error = "Date of birth does not meet age requirements" });
                    return;
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
