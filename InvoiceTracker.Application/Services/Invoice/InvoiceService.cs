using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Enum;
using InvoiceTracker.Application.Repository;
using InvoiceTracker.Application.Services.Invoice.InvoiceEscalation;
using InvoiceTracker.Application.Services.Notification;

namespace InvoiceTracker.Application.Services.Invoice
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationService _notificationService;
        public InvoiceService(IUnitOfWork unitOfWork, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _notificationService = notificationService;
        }

        public async Task SendInvoiceSLAReminders()
        {

            var escalationRules = await _unitOfWork.Invoices.GetEscalationRulesAsync();
            if (escalationRules == null || escalationRules.Count == 0)
                return;

            var escalationGroups = await _unitOfWork.Invoices.GetInvoiceEscalationGroupsAsync();
            if (escalationGroups == null || escalationGroups.Count == 0)
                return;

            var escalationLevels = GetInvoiceEscalators();
            if (escalationLevels == null)
                return ;



            foreach (var level in escalationLevels)
                await level.Escalate(new InvoiceEscalationParameterDto { EscalationRules = escalationRules, EscalationGroups = escalationGroups });

        }

        private IEnumerable<IInvoiceEscalator> GetInvoiceEscalators()
        {
            return new List<IInvoiceEscalator>() {
                   new AdminInvoiceEscalator(_unitOfWork, _notificationService),
                   new ManagerInvoiceEscalator(_unitOfWork, _notificationService),
                   new SeniorManagerInvoiceEscalator(_unitOfWork, _notificationService)
           };
        }

        public async Task<int> CreateInvoice(InvoiceDto invoice)
        {
            var result = await _unitOfWork.Invoices.CreateInvoiceAsync(invoice);
            return result;
        }

        public Task<InvoiceDto> GetInvoice(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> PayInvoice(int invoiceId, decimal amount)
        {
            var invoice = await _unitOfWork.Invoices.GetInvoiceAsync(invoiceId);
            if (invoice == null)
                throw new Exception($"Invoice {invoiceId} not found");

            return await _unitOfWork.Invoices.CreateInvoicePaymentEntryAsync(invoiceId, amount);
        }

        public async Task ProcessInvoicePayment(PaymentDto payment)
        {
            if(payment == null)
                throw new Exception("Payment payload is null");

            if (payment.Proccesed)
            {
                var paymentEntry = await _unitOfWork.Invoices.GetInvoicePaymentEntryAsync(payment.ReferenceNumber);
                if (paymentEntry == null)
                    return;

                var invoiceLineItems = await _unitOfWork.Invoices.GetInvoiceLineItemsAsync(paymentEntry.InvoiceId);

                if (invoiceLineItems == null || invoiceLineItems.Count == 0)
                    return;

                var totalInvoiceAmount = invoiceLineItems.Sum(s => s.UnitPrice * s.Quantity);

                if (totalInvoiceAmount <= payment.Amount)
                    await _unitOfWork.Invoices.UpdateInvoiceStateAsync(paymentEntry.InvoiceId, InvoiceStatusEnum.Paid);

            }

           
        }
    }
}
