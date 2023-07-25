namespace TransDev.Invoicing.Application.Common.Interfaces;

using System;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemUserService
{
    Task<Guid> CreateUserAsync(SystemUser systemUser, CancellationToken token);
    Task<bool> DeleteUserAsync(int userId, CancellationToken token);
    Task<bool> UpdateUserAsync(SystemUser systemUser, CancellationToken token);
}
