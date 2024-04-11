using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using TheBigStore.Repository.Interfaces.EmailInterfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories.EmailRepositories
{

    public class EmailRepository : IEmailRepository
    {
        private readonly string host;
        private readonly int port;
        private readonly SecureSocketOptions options;

        public EmailRepository(string Host, int port = 25, SecureSocketOptions options = SecureSocketOptions.Auto)
        {
            host = Host;
            this.port = port;
            this.options = options;
        }

        // Send an email to the user with a link to reset their password
        public async Task SendPasswordResetAsync(User user)
        {

            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                MimeMessage msg = new();
                msg.From.Add(new MailboxAddress("TheBigStore", "Noreply@TheBigStore.dk"));
                msg.To.Add(new MailboxAddress(user.UserName, user.Email));
                msg.Subject = "Password Reset";

                msg.Body = new TextPart("html")
                {
                    Text = $"""
                    <p style="font-family:'Bauhaus 93'; font-size:30px; text-align: center;">TheBigStore</p>
                    <hr/>
                    <h4>Hello {user.UserName}</h4>    

                    <p>Click the link below to reset your password</p>
                    <a href="">Reset Password</a>
                """
                };

                await SendEmailAsync(msg);
            }
        }

        // Connection and sending msg
        public async Task SendEmailAsync(MimeMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            else
            {
                using SmtpClient smtpClient = new();
                await smtpClient.ConnectAsync(host, port, options);
                if (smtpClient.IsConnected)
                {
                    await smtpClient.SendAsync(message);
                }

                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
