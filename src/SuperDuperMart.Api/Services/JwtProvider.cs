using Microsoft.Extensions.Options;
using SuperDuperMart.Api.Models;
using System.IdentityModel.Tokens.Jwt;

namespace SuperDuperMart.Api.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _jwtSettings;

        public JwtProvider(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken()
        {
            var token = new JwtSecurityToken();
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public bool ValidateToken()
        {
            throw new NotImplementedException();
        }
    }
}
