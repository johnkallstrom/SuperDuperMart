using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMart.Api.Models;

namespace SuperDuperMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticateController(IJwtProvider jwtProvider, IRepository<Customer> customerRepository)
        {
            _jwtProvider = jwtProvider;
            _customerRepository = customerRepository;
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
