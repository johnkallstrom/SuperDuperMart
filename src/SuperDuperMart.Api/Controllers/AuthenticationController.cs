using Microsoft.AspNetCore.Identity;

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
        public async Task<IActionResult> Login([FromBody] LoginModel model)
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

            string token = _jwtProvider.GenerateToken(user);
            return Ok(new { Success = true, Token = token });
        }
    }
}
