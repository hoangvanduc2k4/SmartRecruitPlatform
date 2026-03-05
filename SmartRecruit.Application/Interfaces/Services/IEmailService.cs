namespace SmartRecruit.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
        Task SendHtmlEmailAsync(string to, string subject, string htmlBody);
    }
}
