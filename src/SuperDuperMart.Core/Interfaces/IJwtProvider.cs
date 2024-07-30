namespace SuperDuperMart.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken(User user, string[] roles);
        Task<(bool IsValid, int? UserId)> ValidateToken(string token);
    }
}
