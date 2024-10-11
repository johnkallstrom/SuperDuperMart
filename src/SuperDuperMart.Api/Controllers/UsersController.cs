using SuperDuperMart.Shared.Models;

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
        public async Task<IActionResult> Get(int? pageNumber, int? pageSize)
        {
            if (pageNumber.HasValue && pageSize.HasValue)
            {
                var result = await _unitOfWork.UserRepository.GetPaginatedAsync(pageNumber.Value, pageSize.Value);
                return Ok(new PaginatedModel<UserModel>
                {
                    PageNumber = pageNumber.Value,
                    PageSize = pageSize.Value,
                    Pages = result.Pages,
                    Data = _mapper.Map<IEnumerable<UserModel>>(result.Data)
                });
            }

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
            if (!ModelState.IsValid) return BadRequest();

            var user = _mapper.Map<User>(model);
            var createdUser = await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetById), new { createdUser.Id }, createdUser);
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
