using EmailSenderApp.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
            Database.Migrate();
        }
        public DbSet<EmailModel> EmailChecks { get; set; }
        public DbSet<UserModel> Users { get; set; }

    }
}
