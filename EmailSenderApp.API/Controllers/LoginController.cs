using EmailSenderApp.Application.Services.LoginServices;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpPost]
        public Task<string> Login(string username, string password)
        {
            return _loginService.SendMessage(username, password);
        }

    }
}
