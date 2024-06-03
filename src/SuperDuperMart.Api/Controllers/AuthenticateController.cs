using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMart.Api.Models;

namespace SuperDuperMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticateController(IJwtProvider jwtProvider, IRepository<User> userRepository)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateRequest request)
        {
            // 1. Get user
            // 2. Generate token
            // 3. Send response

            return Unauthorized();
        }
    }
}
