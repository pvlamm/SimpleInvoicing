namespace TransDev.Invoicing.WebUI.Controllers;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseController
{
    public AccountController(IMediator mediator) : base(mediator)
    {
    }
    [HttpGet]
    [Route("")]
    public async Task<ActionResult<AccountsPagination> Get(CancellationToken token){
        }
}
