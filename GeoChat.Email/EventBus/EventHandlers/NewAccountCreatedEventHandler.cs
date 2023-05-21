using GeoChat.Email.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace GeoChat.Email.EventBus.EventHandlers;

internal class NewAccountCreatedEventHandler : IEventHandler<NewAccountCreatedEvent>
{
    private string fromMail;
    private string fromPassword;

    public NewAccountCreatedEventHandler(IConfiguration configuration)
    {		
		fromMail = configuration["Email:fromMail"];
		fromPassword = configuration["Email:fromPassword"];
    }
    public Task HandleAsync(NewAccountCreatedEvent @event)
    {
        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = "Welcome to GeoChat";
        message.To.Add(new MailAddress(@event.Email));

        string welcomeMessage = $"Dear {@event.UserName},\n\n" +
                                "Welcome to GeoChat!\n\n" +
                                "We are delighted to have you as a new member of our community. GeoChat is a vibrant platform where you can connect with people, share experiences, and explore exciting conversations.\n\n" +
                                "If you have any questions or need assistance, please don't hesitate to reach out to our support team. They are always ready to help.\n\n" +
                                "Once again, welcome aboard! Enjoy your journey on GeoChat!\n\n" +
                                "Best regards,\n" +
                                "The GeoChat Team";

        message.Body = $"<html><body><pre>{welcomeMessage}</pre></body></html>";
        message.IsBodyHtml = true;

        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true
        };

        smtpClient.Send(message);
        return Task.CompletedTask;
    }
}
