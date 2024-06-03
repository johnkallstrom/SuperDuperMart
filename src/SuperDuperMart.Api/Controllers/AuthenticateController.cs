using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMart.Api.Models;

namespace SuperDuperMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticateController(IJwtProvider jwtProvider, IUnitOfWork unitOfWork)
        {
            _jwtProvider = jwtProvider;
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest request)
        {
            // 1. Find user by email
            // 2. Check password
            // 3. Generate token
            // 4. Send back response

            var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (user is null)
            {
                return NotFound();
            }

            // Encrypt/Decrypt
            bool validPassword = user.PasswordHash.Equals(request.Password);
            if (!validPassword)
            {
                return Unauthorized();
            }

            string token = _jwtProvider.GenerateToken(user);
            return Ok(token);
        }
    }
}
