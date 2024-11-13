using Microsoft.AspNetCore.Identity;
using SuperDuperMart.Core.Entities.Identity;

namespace SuperDuperMart.Api.Authorization
{
    public class JwtMiddleware
    {
        private readonly IMapper _mapper;
        private readonly IJwtProvider _jwtProvier;
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next, IJwtProvider jwtProvier, IMapper mapper)
        {
            _next = next;
            _jwtProvier = jwtProvier;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext httpContext, UserManager<User> userManager)
        {
            string? token = httpContext.Request.Headers.Authorization.ToString().Split(' ').Last();
            if (!string.IsNullOrEmpty(token))
            {
                var validationResult = await _jwtProvier.ValidateToken(token);
                if (validationResult.IsValid && validationResult.UserId.HasValue)
                {
                    User? user = await userManager.FindByIdAsync(validationResult.UserId.Value.ToString());
                    if (user != null)
                    {
                        httpContext.Items.Add("User", _mapper.Map<UserDto>(user));
                    }
                }
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
