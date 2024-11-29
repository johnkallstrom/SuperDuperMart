namespace SuperDuperMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository<User> _userRepository;

        public AuthenticationController(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _userRepository.LoginAsync(model.Email, model.Password);
            return Ok(new LoginResponse(
                result.Succeeded, 
                result.Token, 
                result.Errors));
        }
    }
}
