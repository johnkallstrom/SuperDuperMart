namespace SuperDuperMart.Web.Services
{
    public interface IHttpService<T>
    {
        Task<IEnumerable<T>> GetListAsync();
    }
}
