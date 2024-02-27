using EmailSenderApp.Application.Services.EmailServices;
using EmailSenderApp.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public LoginController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserModel user)
        {
            bool isValidCredentials = await _emailService.VerifyCredentials(user);

            if (isValidCredentials)
            {
                return Ok("Login is true");
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

    }
}
