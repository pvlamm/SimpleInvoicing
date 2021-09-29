using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Application.Authentication.Queries.GetMyProfile
{
    public class GetMyProfileQuery : IRequest<>
    {
        public string Token { get; set; }
    }

    public class GetMyProfileQueryHandler : 
}
