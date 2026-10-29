namespace InvoiceTracker.Application.Integration.Notification
{
    public interface IEmailIntegration
    {
        Task SendEmail(string fromEmail, string toEmail, string subject, string body);
    }
}
