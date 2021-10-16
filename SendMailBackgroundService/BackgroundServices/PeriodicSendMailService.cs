using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SendMailBackgroundService.Models;

namespace SendMailBackgroundService.BackgroundServices
{
    public class PeriodicSendMailService:BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private  InMemoryContext _context { get; set; }
        public PeriodicSendMailService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
         
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
          Console.WriteLine("Service started");
          return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            _context = scope.ServiceProvider.GetRequiredService<InMemoryContext>();
            await _context.SaveChangesAsync();
            
            while(!stoppingToken.IsCancellationRequested)
            {
                SendMail();
                Console.WriteLine("Mails sent.");
                await Task.Delay(30000, stoppingToken);
            }
        }

        private void SendMail()
        {
            var mailList = _context.UserMails.ToList();
            
            mailList.ForEach(email =>
            {

                MailMessage mailMessage = new();
                SmtpClient smtpClient = new()
                {
                    Credentials = new System.Net.NetworkCredential("example@gmail.com", "examplepassword"),
                    Port = 587,
                    Host = "smtp.gmail.com",
                    EnableSsl = true
                };


                mailMessage.To.Add(email.Email);
                mailMessage.From = new MailAddress("example@gmail.com");
                mailMessage.Subject = "Test mail service";
                mailMessage.Body = $"<p>This e-mail was sent from Net Core Background Service.</p>";
                mailMessage.IsBodyHtml = true;

                smtpClient.Send(mailMessage);
            });
           
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}