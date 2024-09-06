using SuperDuperMart.Api.Parameters;
using SuperDuperMart.Core.Results;

namespace SuperDuperMart.Api.Controllers
{
    [HasAccess]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductQueryParams parameters)
        {
            var model = Enumerable.Empty<ProductModel>();

            if (parameters.CurrentPage.HasValue && parameters.PageSize.HasValue)
            {
                int currentPage = parameters.CurrentPage.Value;
                int pageSize = parameters.PageSize.Value;

                int totalProducts = await _unitOfWork.ProductRepository.CountAsync();
                int totalPages = totalProducts / pageSize;

                if (currentPage <= 0)
                {
                    return BadRequest(PaginatedResult<ProductModel>.Failure([$"The current page '{currentPage}' can't be a negative number"]));
                }

                if (currentPage > totalPages)
                {
                    return BadRequest(PaginatedResult<ProductModel>.Failure([$"The current page can't be greater than the total pages of {totalPages}"]));
                }

                var pagedProducts = await _unitOfWork.ProductRepository.GetAsync(parameters);
                model = _mapper.Map<IEnumerable<ProductModel>>(pagedProducts);

                var result = PaginatedResult<ProductModel>.Ok(
                    currentPage,
                    pageSize,
                    totalPages,
                    model);

                return Ok(result);
            }

            var products = await _unitOfWork.ProductRepository.GetAsync();
            model = _mapper.Map<IEnumerable<ProductModel>>(products);

            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductModel>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateModel model)
        {
            var product = _mapper.Map<Product>(model);
            var newProduct = await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateModel model)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            product = _mapper.Map(source: model, destination: product);

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
