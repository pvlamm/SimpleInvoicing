using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Interfaces;

namespace TransDev.Invoicing.Application.Authentication.Queries.AuthenticateUser
{
    public class AuthenticateUserQuery : IRequest<AuthenticateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticateUserQueryHandler : IRequestHandler<AuthenticateUserQuery, AuthenticateUserResponse>
    {
        private readonly IAuthenticationService _service;

        public AuthenticateUserQueryHandler(IAuthenticationService service)
        {
            _service = service;
        }

        public async Task<AuthenticateUserResponse> Handle(AuthenticateUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.AuthenticateAsync(request.Username, request.Password);

            return new AuthenticateUserResponse
            {
                IsSuccess = result
            };
        }
    }
}
