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
        var guid = Guid.Parse("76D888A4-88C5-4276-ABEC-36EC4D44027F");
        return new SystemUser
        {
            Id = 1,
            DisplayName = "Patrick Lamm",
            Email = "lammster@gmail.com",
            Password = "this is a test",
            PublicId = guid
        };
    }
}
