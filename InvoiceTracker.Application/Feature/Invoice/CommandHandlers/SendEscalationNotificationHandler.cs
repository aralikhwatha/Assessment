using InvoiceTracker.Application.Domain.Base;
using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Services.Invoice;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.CommandHandlers
{
    public class SendEscalationNotificationHandler : IRequestHandler<SendEscalationNotificationCommand, BaseResponse<bool>>
    {
        private readonly IInvoiceService _invoiceService;
        public SendEscalationNotificationHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<BaseResponse<bool>> Handle(SendEscalationNotificationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            await _invoiceService.SendInvoiceSLAReminders();
            response.Succcess = true;
            return response;

        }
    }
}
