using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Services.Http
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        private readonly int _defaultPageNumber;
        private readonly int _defaultPageSize;

        public ProductHttpService(IHttpService httpService, IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;

            _defaultPageNumber = _configuration.GetValue<int>("Pagination:Default:PageNumber");
            _defaultPageSize = _configuration.GetValue<int>("Pagination:Default:PageSize");
        }

        public async Task<PagedListDto<ProductDto>> GetAsync()
        {
            string url = $"{Endpoints.Products}?pageNumber={_defaultPageNumber}&pageSize={_defaultPageSize}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(int pageNumber)
        {
            string url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={_defaultPageSize}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(string sortBy, string sortOrder)
        {
            string url = $"{Endpoints.Products}?pageNumber={_defaultPageNumber}&pageSize={_defaultPageSize}&sortBy={sortBy}&sortOrder={sortOrder}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(int pageNumber, string sortBy, string sortOrder)
        {
            string url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={_defaultPageSize}&sortBy={sortBy}&sortOrder={sortOrder}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }
    }
}
