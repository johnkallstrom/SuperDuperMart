using System.Security.Claims;

namespace SuperDuperMart.Web.Services
{
    public interface IAuthenticationService
    {
        Task<ClaimsPrincipal> GetCurrentUserAsync();
        Task BeginUserSessionAsync(string? token);
        Task EndUserSessionAsync();
    }
}
