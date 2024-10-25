using SuperDuperMart.Core.Entities.Identity;
using SuperDuperMart.Shared.Models;
using SuperDuperMart.Api.Filters;

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

        [ConfirmPassword]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateModel model)
        {
            var user = _mapper.Map<User>(model);

            var result = await _unitOfWork.UserRepository.CreateAsync(user, model.Password);
            return Ok(new 
            { 
                result.Succeeded, 
                result.Errors 
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateModel model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            if (user.Location is not null)
            {
                user.Location = _mapper.Map(source: model.Location, destination: user.Location);
                _unitOfWork.LocationRepository.Update(user.Location);
                await _unitOfWork.SaveAsync();
            }

            user = _mapper.Map(source: model, destination: user);
            await _unitOfWork.UserRepository.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            _unitOfWork.UserRepository.Delete(user);

            return NoContent();
        }
    }
}
