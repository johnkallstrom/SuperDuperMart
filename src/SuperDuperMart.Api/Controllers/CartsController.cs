using SuperDuperMart.Shared.Models.Carts;

namespace SuperDuperMart.Api.Controllers
{
    [HasAccess]
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var carts = await _unitOfWork.CartRepository.GetAsync();

            return Ok(_mapper.Map<IEnumerable<CartModel>>(carts));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(id);

            return Ok(_mapper.Map<CartModel>(cart));
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var cart = await _unitOfWork.CartRepository.GetByUserIdAsync(userId);

            return Ok(_mapper.Map<CartModel>(cart));
        }
    }
}
