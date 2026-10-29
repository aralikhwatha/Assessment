using InvoiceTracker.Application.Feature.Invoice.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateInvoiceAsync([FromBody] CreateInvoiceCommand command)
        {
            if (command is null) return BadRequest();

            var response = await _mediator.Send(command);

            if (response.Succcess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("MakePayment")]
        public async Task<ActionResult> CreateInvoicePaymentEntryAsync([FromBody] PayInvoiceCommand command)
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
