using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransDev.Invoicing.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        public AuthenticationController(IMediator mediator)
            : base(mediator)
        {

        }


    }
}
