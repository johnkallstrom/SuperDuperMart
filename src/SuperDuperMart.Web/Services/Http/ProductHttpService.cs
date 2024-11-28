using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Services.Http
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        public ProductHttpService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync()
        {
            int defaultPageNumber = _configuration.GetValue<int>("Pagination:Default:PageNumber");
            int defaultPageSize = _configuration.GetValue<int>("Pagination:Default:PageSize");

            string url = $"{Endpoints.Products}?pageNumber={defaultPageNumber}&pageSize={defaultPageSize}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(int pageNumber)
        {
            int defaultPageSize = _configuration.GetValue<int>("Pagination:Default:PageSize");

            string url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={defaultPageSize}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(int pageNumber, string sortBy, string sortOrder)
        {
            int defaultPageSize = _configuration.GetValue<int>("Pagination:Default:PageSize");

            string url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={defaultPageSize}&sortBy={sortBy}&sortOrder={sortOrder}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }
    }
}
