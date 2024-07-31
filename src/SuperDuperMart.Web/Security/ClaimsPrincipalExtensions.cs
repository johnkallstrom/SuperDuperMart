using System.Security.Claims;

namespace SuperDuperMart.Web.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int? FindUserIdentifier(this ClaimsPrincipal principal)
        {
            if (principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                Claim? claim = principal.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                if (claim != null)
                {
                    int userId = int.Parse(claim.Value);
                    return userId;
                }
            }

            return default;
        }

        public static string? FindEmail(this ClaimsPrincipal principal)
        {
            if (principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                Claim? claim = principal.FindFirst(c => c.Type == ClaimTypes.Email);
                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return default;
        }

        public static string? FindUri(this ClaimsPrincipal principal)
        {
            if (principal.Identity != null && principal.Identity.IsAuthenticated)
            {
                Claim? claim = principal.FindFirst(c => c.Type == ClaimTypes.Uri);
                if (claim != null)
                {
                    return claim.Value;
                }
            }

            return default;
        }
    }
}
