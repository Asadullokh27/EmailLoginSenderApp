using EmailSenderApp.Application.Services.EmailServices;
using EmailSenderApp.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {


        private readonly IEmailService _emailService;

        public MainController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("email")]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel model)
        {
            await _emailService.SendMessageAsync(model);



            return Ok("Email Sent Successfully");
        }


        [HttpPost]
        public async Task<IActionResult> CheckCode([FromBody] string code)
        {
            bool isCodeCorrect = await _emailService.CheckEmailAsync(code);

            if (isCodeCorrect)
            {
                return Ok("Code is correct");
            }
            else
            {
                return BadRequest("Incorrect code");
            }
        }


        [HttpPost("password")]
        public async Task<IActionResult> SetPassword([FromBody] UserModel user)
        {
            await _emailService.AddUser(user);

            if (user.Status)
            {
                return Ok("Already Registered");
            }

            return Ok("Password set successfully");
        }

    }
}
