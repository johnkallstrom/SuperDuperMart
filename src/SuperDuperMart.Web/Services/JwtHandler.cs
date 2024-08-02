using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace SuperDuperMart.Web.Services
{
    public class JwtHandler : IJwtHandler
    {
        public bool HasTokenExpired(string token)
        {
            var handler = new JsonWebTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jsonWebToken = handler.ReadJsonWebToken(token);
                var validTo = jsonWebToken.ValidTo;
                var now = DateTime.UtcNow;

                return now > validTo;
            }

            return true;
        }

        public IEnumerable<Claim> ReadClaimsFromToken(string token)
        {
            var handler = new JsonWebTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jsonWebToken = handler.ReadJsonWebToken(token);
                if (jsonWebToken != null)
                {
                    return jsonWebToken.Claims;
                }
            }

            return Enumerable.Empty<Claim>();
        }
    }
}
