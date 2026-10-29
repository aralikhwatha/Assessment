using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;
using InvoiceTracker.Application.Repository;
using InvoiceTracker.Application.Services.Notification;

namespace InvoiceTracker.Application.Services.Invoice.InvoiceEscalation
{
    public class ManagerInvoiceEscalator : IInvoiceEscalator
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;

        public ManagerInvoiceEscalator(IUnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task Escalate(InvoiceEscalationParameterDto parameters)
        {
            var rules = parameters?.EscalationRules?.Where(r => r.EscalationGroupId == (int)EscalationGroupEnum.Manager).ToList();
            if (rules == null)
                throw new ArgumentNullException(nameof(rules));

            var escalationGroup = parameters?.EscalationGroups?.FirstOrDefault(g => g.EscalationGroupId == (int)EscalationGroupEnum.Manager);
            if (escalationGroup == null)
                return; //or throw some exception

            foreach (var rule in rules)
            {
                var claimsToEscalate = await _unitOfWork.Invoices.GetUnpaidInvoicesAsync(new List<int> { rule.InvoiceStatusId }, rule.MinNumberOfDays, rule.MaxNumberOfDays);
                if (claimsToEscalate != null && claimsToEscalate.Count > 0)
                    await SendEscalation(escalationGroup, claimsToEscalate);
            }

        }

        private async Task SendEscalation(InvoiceEscalationGroupDto escalationGroup, List<UnpaidInvoiceDto> invoices)
        {
            if (invoices == null || invoices.Count == 0)
                return;

            foreach (var invoice in invoices)
            {
                var notificationChannel = (NotificationChannelEnum)escalationGroup.NotificationChannel;
                await _notificationService.SendNotification(new SendNotificationParameterDto
                {
                    EmailSubject = notificationChannel == NotificationChannelEnum.Email ? "Invoice Escalation" : string.Empty,
                    FromEmailAddress = notificationChannel == NotificationChannelEnum.Email ? "test@assessment.co.za" : string.Empty,
                    MessageBody = $"Manager group escalation: invoice ref: {invoice.InvoiceId}, payment date: {invoice.PaymentDate}",
                    NotificationChannel = notificationChannel,
                    SlackChannelName = notificationChannel == NotificationChannelEnum.Slack ? escalationGroup.NotificationChannelIdentifier : string.Empty,
                    ToEmailAddress = notificationChannel == NotificationChannelEnum.Email ? escalationGroup.NotificationChannelIdentifier : string.Empty

                });

            }

        }
    }
}
