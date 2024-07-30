namespace SuperDuperMart.Web.Http
{
    public interface IHttpService
    {
        Task<T?> GetAsync<T>(string url);
        Task<string> PostAsync<T>(string url, T value);
    }
}
