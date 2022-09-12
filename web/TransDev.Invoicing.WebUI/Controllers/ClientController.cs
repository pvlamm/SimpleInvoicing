namespace TransDev.Invoicing.WebUI.Controllers;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientController : BaseController
{
    public ClientController(IMediator mediator) : base(mediator)
    {
    }
}
