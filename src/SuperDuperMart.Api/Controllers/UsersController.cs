namespace SuperDuperMart.Api.Controllers
{
    [HasAccess]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _unitOfWork.UserRepository.GetAsync();
            return Ok(_mapper.Map<IEnumerable<UserModel>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            return Ok(_mapper.Map<UserModel>(user));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateModel model)
        {
            return Created();
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
