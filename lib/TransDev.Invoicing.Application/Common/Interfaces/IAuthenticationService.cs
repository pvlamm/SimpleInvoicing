namespace TransDev.Invoicing.Application.Common.Interfaces;

using System;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string emailaddress, string password, CancellationToken token);
    Task<SystemUser> GetCurrentUserAsync();
}
