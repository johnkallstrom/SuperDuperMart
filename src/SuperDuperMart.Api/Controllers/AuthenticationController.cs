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
            string? token = await _userRepository.AuthenticateAsync(model.Email, model.Password);
            return Ok(token);
        }
    }
}
