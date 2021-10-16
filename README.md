# .NET-Core-Background-Service-Usage


A background service that periodically sends emails to entered email addresses.

![mail-screen](https://user-images.githubusercontent.com/73026903/137584346-e3b4dea4-acda-4a4f-8c9a-0feabbd543a6.png)

## Installation

You should add current email info in SendMail function in PeriodicSendMailService.
No database configuration is required as the EF Core In Memory package is used.

![mail-edit](https://user-images.githubusercontent.com/73026903/137584384-f4d9cabd-9f95-4c9e-ae29-ace9ae8613fd.png)

Background service send email to all addresses in memory at every 30 second. You can edit period for your scenario.

```cs
while(!stoppingToken.IsCancellationRequested)
            {
                SendMail();
                Console.WriteLine("Mails sent.");
                await Task.Delay(30000, stoppingToken);
            }
```
 
