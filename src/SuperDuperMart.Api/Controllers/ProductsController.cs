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
        public async Task<IActionResult> Get(int? pageNumber, int? pageSize)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                var result = await _unitOfWork.ProductRepository.GetPaginatedAsync(pageNumber.Value, pageSize.Value);
                return Ok(new 
                { 
                    Pages = result.Pages,
                    Products = _mapper.Map<IEnumerable<ProductModel>>(result.Data)
                });
            }

            var products = await _unitOfWork.ProductRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(products));
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
