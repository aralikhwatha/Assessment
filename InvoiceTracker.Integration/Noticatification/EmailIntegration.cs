using InvoiceTracker.Application.Integration.Notification;
using Microsoft.Extensions.Logging;

namespace InvoiceTracker.Integration.Noticatification
{
    public class EmailIntegration : IEmailIntegration
    {
        private readonly ILogger<EmailIntegration> _logger;
        public EmailIntegration(ILogger<EmailIntegration> logger)
        {
            _logger = logger;
        }
        public async Task SendEmail(string fromEmail, string toEmail, string subject, string body)
        {
            await Task.CompletedTask;
            _logger.LogInformation($"Email {body} sent to {toEmail} successfully");
        }
    }
}
