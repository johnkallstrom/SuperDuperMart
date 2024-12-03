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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            string? token = await _userRepository.AuthenticateAsync(request.Email, request.Password);
            return Ok(token);
        }
    }
}
