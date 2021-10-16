using Microsoft.EntityFrameworkCore;

namespace SendMailBackgroundService.Models
{
    public class InMemoryContext :DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) :base(options)
        {
            
        }

        public DbSet<UserMail> UserMails { get; set; } 
    }
}