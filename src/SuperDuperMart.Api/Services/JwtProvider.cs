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
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
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

        public async Task<(bool IsValid, int? UserId)> ValidateToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = securityKey
            };

            TokenValidationResult? result = await handler.ValidateTokenAsync(token, parameters);
            if (result.IsValid)
            {
                var claim = result.Claims.FirstOrDefault(c => c.Key.Equals(ClaimTypes.NameIdentifier));
                var userId = int.Parse(claim.Value.ToString());

                return (IsValid: true, UserId: userId);
            }

            return (IsValid: false, UserId: null);
        }
    }
}
