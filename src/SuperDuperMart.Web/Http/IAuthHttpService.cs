namespace SuperDuperMart.Web.Http
{
    public interface IAuthHttpService
    {
        Task SendLoginRequest(string email, string password, bool isAdministrator = false);
    }
}
