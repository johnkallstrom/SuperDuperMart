using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Services.Http
{
    public interface IProductHttpService
    {
        Task<PagedListDto<ProductDto>> GetAsync();
        Task<PagedListDto<ProductDto>> GetAsync(int pageNumber);
        Task<PagedListDto<ProductDto>> GetAsync(int pageNumber, string sortBy, string sortOrder);
    }
}
