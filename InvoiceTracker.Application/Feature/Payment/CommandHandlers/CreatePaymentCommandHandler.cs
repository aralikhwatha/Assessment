using InvoiceTracker.Application.Domain.Base;
using InvoiceTracker.Application.Feature.Payment.Commands;
using InvoiceTracker.Application.Services.Payment;
using MediatR;

namespace InvoiceTracker.Application.Feature.Payment.CommandHandlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, BaseResponse<bool>>
    {
        private readonly IPaymentService _paymentService;
        public CreatePaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<BaseResponse<bool>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            await _paymentService.Pay(command.PaymentReference, command.Amount);
            response.Succcess = true;
            return response;
        }
    }
}
