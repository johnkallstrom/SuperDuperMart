namespace SuperDuperMart.Shared.Models.Users
{
    public record LoginModel(string Email, string Password, bool IsAdministrator = false);
}
