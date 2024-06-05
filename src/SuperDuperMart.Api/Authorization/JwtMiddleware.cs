namespace SuperDuperMart.Api.Authorization
{
    public class JwtMiddleware
    {
        private readonly IJwtProvider _jwtProvier;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IJwtProvider jwtProvier)
        {
            _next = next;
            _jwtProvier = jwtProvier;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUnitOfWork unitOfWork)
        {
            string? token = httpContext.Request.Headers.Authorization.ToString().Split(' ').Last();
            if (!string.IsNullOrEmpty(token))
            {
                var validationResult = await _jwtProvier.ValidateToken(token);
                if (validationResult.IsValid && validationResult.UserId.HasValue)
                {
                    User? user = await unitOfWork.UserRepository.GetByIdAsync(validationResult.UserId.Value);
                    AttachUserToHttpContext(httpContext, user);
                }
            }

            await _next.Invoke(httpContext);
        }

        private void AttachUserToHttpContext(HttpContext httpContext, User? user)
        {
            if (user != null)
            {
                httpContext.Items.Add("CurrentUser", new
                {
                    user.Id,
                    user.Email,
                    user.Username,
                    user.FirstName,
                    user.LastName,
                });
            }
        }
    }

    public static class JwtMiddlewareExtensions
    {
        public static void UseJwtMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<JwtMiddleware>();
        }
    }
}
