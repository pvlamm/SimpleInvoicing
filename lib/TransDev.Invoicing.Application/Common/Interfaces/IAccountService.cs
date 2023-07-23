namespace TransDev.Invoicing.Application.Common.Interfaces;

using System;
using System.Threading;
using System.Threading.Tasks;

public interface IAccountService
{
    Task<Guid> CreateAccountAsync(string username,  string password, CancellationToken token);
    Task<bool> AccountExists(string username, CancellationToken token);
    Task<bool> SetAccountActiveAsync(Guid publicId, bool active, CancellationToken token);
    Task<bool> AddUserToAccount(Guid publicId, Guid systemUserPublicId, CancellationToken token);

}
