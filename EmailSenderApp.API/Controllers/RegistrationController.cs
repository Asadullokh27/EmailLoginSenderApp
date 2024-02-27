using EmailSenderApp.Application.Services.RegistrationServices;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpPost]
        public async Task<string> Register2(string username, string password)
        {
            return await _registrationService.Register(username, password);
        }

    }
}
