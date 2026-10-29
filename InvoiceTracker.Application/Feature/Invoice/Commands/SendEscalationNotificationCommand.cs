using InvoiceTracker.Application.Domain.Base;
using MediatR;

namespace InvoiceTracker.Application.Feature.Invoice.Commands
{
    public class SendEscalationNotificationCommand: IRequest<BaseResponse<bool>>
    {
    }
}
