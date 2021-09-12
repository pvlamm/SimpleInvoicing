using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Authentication.Queries.AuthenticateUser;
using TransDev.Invoicing.Application.Common.Models;
using System.Security.Claims;
using TransDev.Invoicing.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using TransDev.Invoicing.Application.Common.Helpers;
using TransDev.Invoicing.Application.Common.Exceptions;
using Microsoft.Identity.Web.Resource;

namespace TransDev.Invoicing.WebUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration _config;
        private readonly IDateTime _dateTime;

        // The web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public AuthenticationController(IConfiguration config, IDateTime dateTime, IMediator mediator)
            : base(mediator)
        {
            _config = config;
            _dateTime = dateTime;
        }

        [AllowAnonymous]
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK, typeof(AuthenticateUserQuery), Description = "System User Authentication. Response includes a JWT token to authorize future requests.")]
        [SwaggerResponse(HttpStatusCode.BadRequest, typeof(SerializableException), Description = "User not authorized. Returns exception details.")]
        public async Task<ActionResult<AuthenticateUserResponse>> Authenticate([FromBody] AuthenticateUserQuery query)
        {
            HttpContext.VerifyUserHasAnyAcceptedScope(scopeRequiredByApi);

            try
            {
                var response = await _mediator.Send(query);
                if (!response.IsSuccess)
                    throw new UnauthorizedAccessException("Attempted to login to a deactivated user");

                var token = CreateJWTToken(query.Username);

                return new AuthenticateUserResponse()
                {
                    Token = token.Token,
                    ExpiresAt = token.ExpiresAt,
                    IsSuccess = response.IsSuccess,
                    Username = query.Username
                };
            }
            catch (Exception ex)
            {
                return BadRequest(new SerializableException(ex));
            }
        }


        private JWTTokenModel CreateJWTToken(string user)
        {
            var credentials = new SigningCredentials(_config.JWTKey(), SecurityAlgorithms.HmacSha256);
            var expiresAt = _dateTime.Now.AddMinutes(_config.JWTExpiresAfterXMinutes());

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user)
            };

            var token = new JwtSecurityToken(
                issuer: _config.JWTIssuer(),
                audience: _config.JWTIssuer(),
                claims: claims.ToArray(),
                expires: expiresAt,
                signingCredentials: credentials
            );
            var value = new JwtSecurityTokenHandler().WriteToken(token);

            return new JWTTokenModel()
            {
                Token = value,
                ExpiresAt = expiresAt
            };
        }
    }
}
