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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            string? token = httpContext.Request.Headers.Authorization.ToString().Split(' ').Last();
            if (!string.IsNullOrEmpty(token))
            {
            }

            await _next.Invoke(httpContext);
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
