namespace TransDev.Invoicing.WebUI.Controllers;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using NSwag.Annotations;

using TransDev.Invoicing.Application.Common.Exceptions;
using TransDev.Invoicing.Application.Invoices.Commands;
using TransDev.Invoicing.Application.Invoices.Queries;

[Route("api/[controller]/[action]")]
[ApiController]
public class InvoiceController : BaseController
{
    public InvoiceController(IMediator mediator) : base(mediator)
    {
    }

    // public 
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateInvoiceCommand), Description = "New Invoice Command")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<CreateInvoiceResponse>> Post(CreateInvoiceCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{publicId}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(Guid), Description = "Get Invoice by PublicId")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<GetInvoiceByPublicIdQueryResponse>> Get(Guid publicId, CancellationToken token)
    {
        var result = await _mediator.Send(new GetInvoiceByPublicIdQuery { PublicId = publicId }, token);

        return Ok(result);
    }
}
