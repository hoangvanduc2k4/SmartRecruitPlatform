using Microsoft.Extensions.Options;
using SmartRecruit.Application.Interfaces.Services;
using SmartRecruit.Infrastructure.Configurations;
using System.Net;
using System.Net.Mail;

namespace SmartRecruit.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            await SendAsync(to, subject, body, false);
        }

        public async Task SendHtmlEmailAsync(string to, string subject, string htmlBody)
        {
            await SendAsync(to, subject, htmlBody, true);
        }

        private async Task SendAsync(string to, string subject, string body, bool isHtml)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                using var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port)
                {
                    Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.Password),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false
                };

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log exception here if logger is configured
                throw new Exception($"Failed to send email to {to}: {ex.Message}", ex);
            }
        }
    }
}
