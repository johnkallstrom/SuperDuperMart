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
        public async Task<IActionResult> Get([FromQuery] QueryParams parameters)
        {
            var pagedList = await _unitOfWork.ProductRepository.GetAsync(parameters);
            return Ok(_mapper.Map<PagedListDto<ProductDto>>(pagedList));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDto dto)
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(dto.CategoryId);
            if (productCategory is null)
            {
                return NotFound(new { ProductCategoryId = dto.CategoryId });
            }

            var product = _mapper.Map<Product>(dto);
            var newProduct = await _unitOfWork.ProductRepository.CreateAsync(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { newProduct.Id }, _mapper.Map<ProductDto>(newProduct));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductUpdateDto dto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            product = _mapper.Map(source: dto, destination: product);

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
