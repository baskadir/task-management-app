using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System;
using TaskManagement.Business.Interfaces;

namespace TaskManagement.Business.Services
{
    public class EmailService : IEmailService
    {
        public bool SendEmail(string email, string role, string text)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Task Management App", ""));
            message.To.Add(MailboxAddress.Parse(email));

            switch (role)
            {
                case "Manager":
                    message.Subject = "Bilgilendirme";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = $"<p>{text}</p>"
                    };
                    break;
                case "Personel":
                    message.Subject = "Bilgilendirme";
                    message.Body = new TextPart(TextFormat.Html)
                    {
                        Text = $"<p>{text}</p>"
                    };
                    break;
            }

            string fromEmail = "";
            string fromPassword = "";

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(fromEmail, fromPassword);
                smtpClient.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
