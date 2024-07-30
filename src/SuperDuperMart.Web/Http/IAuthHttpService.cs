using SuperDuperMart.Shared.Models.Authentication;

namespace SuperDuperMart.Web.Http
{
    public interface IAuthHttpService
    {
        Task<LoginResult> SendLoginRequest(string email, string password, bool isAdministrator = false);
    }
}
