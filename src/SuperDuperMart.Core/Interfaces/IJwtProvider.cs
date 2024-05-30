namespace SuperDuperMart.Core.Interfaces
{
    public interface IJwtProvider
    {
        string GenerateToken();
        bool ValidateToken();
    }
}
