namespace TransDev.Invoicing.WebUI.Controllers;

using System.Net;
using System.Threading.Tasks;
using System;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

using TransDev.Invoicing.Application.Common.Exceptions;

using TransDev.Invoicing.Application.Items.Commands;
using TransDev.Invoicing.Application.Client.Queries;

[Route("api/[controller]")]
[ApiController]
public class ClientController : BaseController
{
    public ClientController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveClientsResponse), Description = "List of Active Clients")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<CreateItemResponse>> Get([FromBody] GetActiveClientsQuery query)
    {
        try
        {
            var results = await _mediator.Send(query);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }
}
