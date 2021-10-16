using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using SendMailBackgroundService.Models;

namespace SendMailBackgroundService.BackgroundServices
{
    public class PeriodicSendMailService:BackgroundService
    {
        private readonly InMemoryContext _context;

        public PeriodicSendMailService(InMemoryContext context)
        {
            _context = context;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
              SendMail();

              return Task.CompletedTask;
        }

        private void SendMail()
        {
            var mailList = _context.UserMails.ToList();
            
            mailList.ForEach(mail =>
            {
                
                
            });
            
        }

        private void sendmaill(string email)
        {
           
        }
    }
}