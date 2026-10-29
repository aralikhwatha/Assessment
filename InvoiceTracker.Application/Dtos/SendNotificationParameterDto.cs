using InvoiceTracker.Application.Enum;

namespace InvoiceTracker.Application.Dtos
{
    public class SendNotificationParameterDto
    {
        public NotificationChannelEnum NotificationChannel { get; set; }
        public string? MessageBody { get; set; }
        public string? FromEmailAddress { get; set; }
        public string? ToEmailAddress { get; set; }
        public string? EmailSubject { get; set; }
        public string? SlackChannelName { get; set; }

    }
}
