using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMart.Api.Models;

namespace SuperDuperMart.Api.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtProvider _jwtProvider;

        public AuthenticateController(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
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
