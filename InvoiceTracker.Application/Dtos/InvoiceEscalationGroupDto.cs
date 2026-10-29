namespace InvoiceTracker.Application.Dtos
{
    public class InvoiceEscalationGroupDto
    {
        public int EscalationGroupId { get; set; }
        public string? Description { get; set; }
        public int NotificationChannel { get; set; }
        public string? NotificationChannelIdentifier { get; set; }
    }
}
