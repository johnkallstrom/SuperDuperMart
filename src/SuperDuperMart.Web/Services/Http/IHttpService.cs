namespace SuperDuperMart.Web.Services.Http
{
    public interface IHttpService
    {
        Task<T?> GetAsync<T>(string url);
        Task PostAsync(string url);
        Task PostAsync<T>(string url, T value);
        Task<string?> PostAndRetrieveStringAsync<T>(string url, T value);
        Task<int?> PostAndRetrieveIntAsync<T>(string url, T value);
        Task PutAsync<T>(string url, T value);
        Task DeleteAsync(string url);
    }
}
