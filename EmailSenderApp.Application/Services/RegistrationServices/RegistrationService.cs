using EmailSenderApp.Domain.Entities.Models;
using EmailSenderApp.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderApp.Application.Services.RegistrationServices
{
    public class RegistrationService : IRegistrationService
    {

        private readonly ApplicationDbContext _context;

        public RegistrationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DoesExist(string useremail)
        {
            var emails = await _context.Users.ToListAsync();
            foreach (var user in emails)
            {
                if (user.UserEmail == useremail) return true;
            }
            return false;
        }

        public async Task<string> Register(string useremail, string password)
        {
            RegistrationService register = new RegistrationService(_context);
            if (!register.DoesExist(useremail).Result)
            {
                var User = new UserModel
                {
                    UserEmail = useremail,
                    UserPassword = password
                };
                await _context.Users.AddAsync(User);
                _context.SaveChanges();
                return "Registered";
            }
            return "Email aready exists";
        }

    }
}
