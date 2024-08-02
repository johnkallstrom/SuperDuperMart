namespace SuperDuperMart.Web.Services
{
    public interface IAuthenticationService
    {
        Task BeginUserSessionAsync(string? token);
        Task EndUserSessionAsync();
    }
}
