using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperDuperMart.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SuperDuperMart.Api.Services
{
    public class JwtProvider : IJwtProvider
    {
        private readonly JwtSettings _jwtSettings;

        public JwtProvider(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer, 
                audience: _jwtSettings.Audience, 
                claims: claims, 
                notBefore: null, 
                expires: DateTime.Now.AddMinutes(60), 
                signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
