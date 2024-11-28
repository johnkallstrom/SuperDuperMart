using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Services.Http
{
    public class ProductHttpService : IProductHttpService
    {
        private readonly IHttpService _httpService;

        public ProductHttpService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<PagedListDto<ProductDto>> GetAsync(int pageNumber, int pageSize, string sortBy, string sortOrder)
        {
            string url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}&sortBy={sortBy}&sortOrder={sortOrder}";

            var data = await _httpService.GetAsync<PagedListDto<ProductDto>>(url);
            if (data is null)
            {
                throw new Exception("Failed to fetch from api");
            }

            return data;
        }
    }
}
