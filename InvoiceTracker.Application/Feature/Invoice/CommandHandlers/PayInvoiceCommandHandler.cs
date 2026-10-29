using InvoiceTracker.Application.Domain.Base;
using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Services.Invoice;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.CommandHandlers
{
    public class PayInvoiceCommandHandler : IRequestHandler<PayInvoiceCommand, BaseResponse<int>>
    {
        private readonly IInvoiceService _invoiceService;
        public PayInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<BaseResponse<int>> Handle(PayInvoiceCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();
            var paymentRef = await _invoiceService.PayInvoice(command.InvoiceId, command.Amount);
            response.Succcess = paymentRef > 0;
            response.Payload = paymentRef;
            return response;
        }
    }
}
