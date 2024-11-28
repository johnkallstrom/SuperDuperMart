using SuperDuperMart.Shared.DTOs;

namespace SuperDuperMart.Web.Services.Http
{
    public interface IProductHttpService
    {
        Task<PagedListDto<ProductDto>> GetAsync(int pageNumber, int pageSize, string sortBy, string sortOrder);
    }
}
