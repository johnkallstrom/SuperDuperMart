namespace SuperDuperMart.Web.Http
{
    public interface IHttpService
    {
        Task<TData?> GetAsync<TData>(string url);
    }
}
