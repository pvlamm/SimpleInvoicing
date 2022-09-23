namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemStateService
{
    Task<SystemState> GetSystemStateByIdAsync(string id, CancellationToken token);
    Task<IEnumerable<SystemState>> GetSystemStatesAsync(CancellationToken token);
    Task<IEnumerable<SystemState>> SearchStatesByNameAsync(string name, CancellationToken token);
    Task<IEnumerable<SystemState>> SearchStatesByIdAsync(string id, CancellationToken token);
}
