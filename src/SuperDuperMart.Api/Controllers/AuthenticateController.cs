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
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);
            if (user is null)
            {
                return NotFound();
            }

            bool validPassword = _unitOfWork.UserRepository.CheckPassword(user, request.Password);
            if (!validPassword)
            {
                return Unauthorized();
            }

            string token = _jwtProvider.GenerateToken(user);
            return Ok(new { Success = true, Token = token });
        }
    }
}
