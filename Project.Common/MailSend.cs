using System;
using System.Net.Mail;
using System.Net;

namespace Project.Common
{
    public class MailSend
    {
        public static void SendEmail(string email, string subject, string message)
        {
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("bilgeotelproj@hotmail.com", "Bilge Hotel");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("bilgeotelproj@hotmail.com", "EmirEren123");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.EnableSsl = true;

            smtpClient.Send(sender);
        }
    }
}
