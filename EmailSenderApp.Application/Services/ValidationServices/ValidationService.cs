using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderApp.Application.Services.ValidationServices
{
    public class ValidationService : IValidationService
    {

        private readonly ApplicationDbContext _checkService;
        public ValidationService(ApplicationDbContext context)
        {
            _checkService = context;
        }
        public async Task<string> CheckAsync(string useremail, string password, string code)
        {
            var res = await _checkService.EmailChecks.ToListAsync();
            foreach (var user in res)
            {
                if (user.Email == useremail && user.Password == password && user.Code == code) return "Welcome to our API";
            }
            return "Something went wrong. Please try again";
        }

    }
}
