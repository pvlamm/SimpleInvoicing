﻿namespace TransDev.Invoicing.ApplicationTests.ServiceMocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class AuthenticationServiceMock : IAuthenticationService
{
    public Task<bool> AuthenticateAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AuthenticateAsync(string emailaddress, string password, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<SystemUser> GetCurrentUserAsync()
    {
        throw new NotImplementedException();
    }
}
