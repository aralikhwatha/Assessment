using InvoiceTracker.Application.Feature.Invoice.Commands;
using InvoiceTracker.Application.Feature.Payment.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> InsertAsync([FromBody] CreatePaymentCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
