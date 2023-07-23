namespace TransDev.Invoicing.WebUI.Controllers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using NSwag.Annotations;

using System;
using System.Net;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Exceptions;
using TransDev.Invoicing.Application.Items.Commands;
using TransDev.Invoicing.Application.Items.Queries;

[Route("api/[controller]")]
[ApiController]
public class ItemController : BaseController
{
    public ItemController(IMediator mediator)
        : base(mediator)
    {

    }

    [HttpPost]
    [Route("")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(CreateItemResponse), Description = "Item successfully Created in the System")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<CreateItemResponse>> CreateItem([FromBody] CreateItemCommand command)
    {
        try
        {
            var results = await _mediator.Send(command);
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }

    [HttpPost]
    [Route("search")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveItemsResponse), Description = "Active Item List Lookup")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<GetActiveItemsResponse>> SearchActiveItems([FromBody] GetActiveItemsQuery query)
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

    [HttpGet]
    [Route("{itemId}/history")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveItemsResponse), Description = "Get Item History by Code or Id")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<GetItemHistoryResponse>> GetItemHistory(int itemId)
    {
        try
        {
            var results = await _mediator.Send(new GetItemHistoryQuery { Id = itemId });
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }

    [HttpGet]
    [Route("{itemId}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveItemsResponse), Description = "Get Item History by Code or Id")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<ItemDto>> GetItemByItemId(int itemId)
    {
        try
        {
            var results = await _mediator.Send(new GetItemQuery { Id = itemId });
            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }
    [HttpDelete]
    [Route("{itemId}")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Get Item History by Code or Id")]
    [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
    public async Task<ActionResult<bool>> DeleteItemById(int itemId)
    {
        try
        {
            //var results = await _mediator.Send(query);
            //return Ok(results);
            
            return Ok(await Task.FromResult(true));
        }
        catch (Exception ex)
        {
            return BadRequest(new SerializableException(ex));
        }
    }
}
