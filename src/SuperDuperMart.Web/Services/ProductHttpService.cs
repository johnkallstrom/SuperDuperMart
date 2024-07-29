namespace SuperDuperMart.Web.Services
{
    public class ProductHttpService
    {
        private readonly HttpClient _httpClient;

        public ProductHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}