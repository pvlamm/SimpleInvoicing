namespace TransDev.Invoicing.WebUI.Controllers;

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using NSwag.Annotations;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Exceptions;
using TransDev.Invoicing.Application.Invoices.Commands;
using TransDev.Invoicing.Application.Invoices.Queries;
using TransDev.Invoicing.Domain.Entities;

[Route("api/[controller]/[action]")]
[ApiController]
public class InvoiceController : BaseController
{
    public InvoiceController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateInvoiceCommand), Description = "New Invoice Command")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<CreateInvoiceResponse>> Post(CreateInvoiceCommand command, CancellationToken token)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{publicId}/status")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateInvoiceCommand), Description = "Update Invoice Status Command")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<bool>> UpdateInvoiceStatus(Guid publicId, [FromBody] byte invoiceStatusId)
    {
        var result = await _mediator.Send(new UpdateInvoiceStatusCommand { PublicId = publicId, SystemInvoiceStatusId = invoiceStatusId });

        return Ok(result);
    }

    [HttpPost("{publicId}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateInvoiceCommand), Description = "Update Invoice Command")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<bool>> UpdateInvoice(Guid publicId, [FromBody] InvoiceDto invoice)
    {
        return Ok(await Task.FromResult(true));
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
