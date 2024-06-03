using SuperDuperMart.Core.Entities;

namespace SuperDuperMart.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}
