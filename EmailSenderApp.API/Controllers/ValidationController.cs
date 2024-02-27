using EmailSenderApp.Application.Services.ValidationServices;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {

        private readonly IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            _validationService = validationService;
        }
        [HttpPost]
        public async Task<string> Validate(string useremail, string password, string code)
        {
            return await _validationService.CheckAsync(useremail, password, code);
        }

    }
}
