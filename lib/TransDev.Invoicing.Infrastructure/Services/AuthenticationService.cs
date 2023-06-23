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
        var publicId = Guid.Parse("D7C9E212-DE28-45D1-9BB7-CFA2A299867C");
        return Task.FromResult(new SystemUser
        {
            Username = "admin",
            DisplayName = "admin",
            Email = "admin@simpleinvoicing.com",
            Id = 1,
            PublicId = publicId
        });
    }
}
