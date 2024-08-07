using Microsoft.AspNetCore.Diagnostics;

namespace SuperDuperMart.Api.ExceptionHandlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Internal Server Error",
                Type = exception.GetType().Name,
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            };

            if (!string.IsNullOrWhiteSpace(exception.Source))
            {
                problemDetails.Extensions.Add("source", exception.Source);
            }

            if (exception.InnerException != null)
            {
                problemDetails.Extensions.Add("error", exception.InnerException.Message);
            }

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
