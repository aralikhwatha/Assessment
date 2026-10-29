using InvoiceTracker.Application.Domain.Base;
using MediatR;

namespace InvoiceTracker.Application.Feature.Payment.Commands
{
    public class CreatePaymentCommand: IRequest<BaseResponse<bool>>
    {
        public int PaymentReference { get; set; }
        public decimal Amount { get; set; }
        
    }
}
