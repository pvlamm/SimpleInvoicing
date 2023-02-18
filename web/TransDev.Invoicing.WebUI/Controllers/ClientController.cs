namespace TransDev.Invoicing.WebUI.Controllers;

using System.Net;
using System.Threading.Tasks;
using System;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

using TransDev.Invoicing.Application.Common.Exceptions;

using TransDev.Invoicing.Application.Items.Commands;
using TransDev.Invoicing.Application.Client.Queries;
using TransDev.Invoicing.Application.Client.Commands;

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
    public async Task<ActionResult<CreateItemResponse>> Get()
    {
        try
        {
            var results = await _mediator.Send(new GetActiveClientsQuery());
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }

    [HttpPost]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateClientResponse), Description = "Create new Client")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<CreateClientResponse>> Post([FromBody] CreateClientCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        catch(Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }
}
