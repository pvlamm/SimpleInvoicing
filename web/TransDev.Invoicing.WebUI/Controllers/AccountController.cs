namespace TransDev.Invoicing.WebUI.Controllers;

using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NSwag.Annotations;

using TransDev.Invoicing.Application.Account.Commands;
using TransDev.Invoicing.Application.Account.Queries;
using TransDev.Invoicing.Application.Client.Queries;
using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Exceptions;

[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    [Route("")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveAccountsPagination), Description = "List of Active Accounts")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<GetActiveAccountsPagination>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 50, CancellationToken token = default)
    {
        try
        {
            var result = await _mediator.Send(new GetActiveAccountsQuery()
            {
                Page = 1,
                PageSize = pageSize,
            });
            return Ok(result);
        }
        catch
        {
            return BadRequest(new SerializableException("") { });
        }
    }

    [HttpPost]
    [Route("")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateAccountCommand), Description = "Create Account")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<Guid>> Post([FromBody] CreateAccountCommand account)
    {
        var result = await _mediator.Send(account);
        return Ok(result);
    }

    [HttpPut]
    [Route("")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(AccountDto), Description = "Update Account")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<Guid>> Put([FromBody] AccountDto account)
    {
        return Ok(Guid.NewGuid());
    }

}
