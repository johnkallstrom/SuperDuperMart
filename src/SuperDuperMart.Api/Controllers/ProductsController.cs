﻿using AutoMapper;

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
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.ProductRepository.GetAsync();

            return Ok(_mapper.Map<IEnumerable<ProductResponse>>(products));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductResponse>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            var product = _mapper.Map<Product>(request);
            var newProduct = await _unitOfWork.ProductRepository.CreateAsync(product);

            return CreatedAtAction(nameof(GetById), new { newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
