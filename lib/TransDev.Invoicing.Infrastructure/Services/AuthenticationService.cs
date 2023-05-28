namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class AuthenticationService : IAuthenticationService
{
    public async Task<bool> AuthenticateAsync(string emailaddress, string password)
    {
        return true;
    }

    public Task<SystemUser> GetCurrentUser()
    {
        throw new NotImplementedException();
    }
}
