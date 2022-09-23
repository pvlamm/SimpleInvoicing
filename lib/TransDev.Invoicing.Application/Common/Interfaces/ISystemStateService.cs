namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemStateService
{
    Task<SystemState> GetSystemStateByIdAsync(string id, CancellationToken token);

    /// <summary>
    /// This will probably never exceed 50 US States + Territories: Guam, Puerto Rico, etc.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<IEnumerable<SystemState>> GetSystemStatesAsync(CancellationToken token);
    Task<IEnumerable<SystemState>> SearchStatesByNameAsync(string name, CancellationToken token);
    Task<IEnumerable<SystemState>> SearchStatesByIdAsync(string id, CancellationToken token);
    Task<bool> SystemStateExistsById(string id, CancellationToken token);
}
