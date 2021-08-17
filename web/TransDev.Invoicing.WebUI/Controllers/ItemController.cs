using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Models;
using TransDev.Invoicing.Application.Items.Commands;
using TransDev.Invoicing.Application.Items.Queries;

namespace TransDev.Invoicing.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : BaseController
    {
        public ItemController(IMediator mediator)
            : base(mediator)
        {

        }

        [HttpPost]
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

        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(GetActiveItemsResponse), Description = "Get Item History by Code or Id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
        public async Task<ActionResult<GetItemHistoryResponse>> GetItemHistory([FromBody] GetItemHistoryQuery query)
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


        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, typeof(bool), Description = "Get Item History by Code or Id")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "Error was thrown")]
        public async Task<ActionResult<bool>> DeleteItemById([FromBody] int itemId)
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
}
