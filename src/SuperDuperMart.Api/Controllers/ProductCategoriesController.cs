namespace SuperDuperMart.Api.Controllers
{
    [Route("api/product-categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoriesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productCategories = await _unitOfWork.ProductCategoryRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<ProductCategoryDto>>(productCategories));
        }
    }
}
