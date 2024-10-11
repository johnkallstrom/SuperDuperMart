using System.Security.Claims;

namespace SuperDuperMart.Web.Services
{
    public interface IJwtHandler
    {
        IEnumerable<Claim> ReadClaimsFromToken(string token);
        bool HasTokenExpired(string token);
        int GetTokenExpirationTimeInMinutes(string token);
    }
}
