using InvoiceTracker.Application.Integration.Notification;
using Microsoft.Extensions.Logging;

namespace InvoiceTracker.Integration.Noticatification
{
    public class SlackIntegration : ISlackIntegration
    {
        private readonly ILogger<EmailIntegration> _logger;
        public SlackIntegration(ILogger<EmailIntegration> logger)
        {
            _logger = logger;
        }
        public async Task SendSlackMessage(string toChannel, string message)
        {
            await Task.CompletedTask;
            _logger.LogInformation($"message {message} sent to {toChannel} slack channel successfully");
        }
    }
}
