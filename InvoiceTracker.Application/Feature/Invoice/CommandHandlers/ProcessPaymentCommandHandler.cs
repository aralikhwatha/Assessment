using InvoiceTracker.Application.Domain.Base;
using InvoiceTracker.Application.Dtos;
using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Services.Invoice;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.CommandHandlers
{
    public class ProcessPaymentCommandHandler : IRequestHandler<ProcessPaymentCommand, BaseResponse<bool>>
    {
        private readonly IInvoiceService _invoiceService;
        public ProcessPaymentCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public async Task<BaseResponse<bool>> Handle(ProcessPaymentCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            await _invoiceService.ProcessInvoicePayment(new PaymentDto
            {
                Amount = command.Amount,
                CreatedAt = command.CreatedAt,
                Proccesed = command.Processed,
                ReferenceNumber = command.PaymentReference,
                ErrorMessage = command.ErrorMessage,

            });
            response.Succcess = true;
            return response;
        }
    }
}
