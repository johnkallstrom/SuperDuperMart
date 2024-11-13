using Microsoft.AspNetCore.Identity;
using SuperDuperMart.Core.Entities.Identity;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticationController(
            IJwtProvider jwtProvider, 
            UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _jwtProvider = jwtProvider;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
            {
                return NotFound();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                return BadRequest(new { Message = "Incorrect password" });
            }

            var roles = await _userManager.GetRolesAsync(user);

            string token = _jwtProvider.GenerateToken(user, roles.ToArray());
            return Ok(token);
        }
    }
}
