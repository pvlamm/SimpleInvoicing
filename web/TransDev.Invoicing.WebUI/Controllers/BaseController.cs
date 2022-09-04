namespace TransDev.Invoicing.WebUI.Controllers;

using MediatR;

using Microsoft.AspNetCore.Mvc;

public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

}
