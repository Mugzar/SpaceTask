using MailKit.Net.Smtp;
using MimeKit;

namespace MovieAPI
{
    public class EmailServiceManager : IEmailServiceManager
    {
        private readonly EmailConfiguration _configuration;
        public EmailServiceManager(EmailConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string receipent, string mailSubject, string mailBody)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration.From));
            emailMessage.To.Add(InternetAddress.Parse(receipent));
            emailMessage.Subject = mailSubject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mailBody };

            Send(emailMessage);
        }

        private void Send(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_configuration.SmtpServer, _configuration.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_configuration.UserName, _configuration.Password);
                    client.Send(mailMessage);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

    }
}
