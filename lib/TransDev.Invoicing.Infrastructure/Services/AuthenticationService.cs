namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class AuthenticationService : IAuthenticationService
{
    public async Task<bool> AuthenticateAsync(string emailaddress, string password)
    {
        return await Task.FromResult(true);
    }

    public async Task<SystemUser> GetCurrentUserAsync()
    {
        var publicId = Guid.Parse("D7C9E212-DE28-45D1-9BB7-CFA2A299867C");
        return await Task.FromResult(new SystemUser
        {
            DisplayName = "admin",
            Email = "admin@simpleinvoicing.com",
            Id = 1,
            PublicId = publicId
        });
    }
}
