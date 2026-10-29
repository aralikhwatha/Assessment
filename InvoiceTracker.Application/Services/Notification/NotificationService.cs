using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;
using InvoiceTracker.Application.Integration.Notification;
using Microsoft.Extensions.Logging;

namespace InvoiceTracker.Application.Services.Notification
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly IEmailIntegration _emailIntegration;
        private readonly ISlackIntegration _slackIntegration;

        public NotificationService(ILogger<NotificationService> logger, IEmailIntegration emailIntegration, ISlackIntegration slackIntegration)
        {
            _logger = logger;
            _emailIntegration = emailIntegration;
            _slackIntegration = slackIntegration;
        }
        public async Task SendNotification(SendNotificationParameterDto parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");

            switch (parameters.NotificationChannel)
            {
                case NotificationChannelEnum.Slack:
                    await _slackIntegration.SendSlackMessage(parameters.SlackChannelName, parameters.MessageBody);
                    break;
                    
                case NotificationChannelEnum.Email:
                    await _emailIntegration.SendEmail(parameters.FromEmailAddress,parameters.ToEmailAddress,parameters.EmailSubject,parameters.MessageBody);
                    break;

                    default:
                    throw new Exception($"NotificationService error: Notification channel {parameters.NotificationChannel} not found");

            }
        }
    }
}
