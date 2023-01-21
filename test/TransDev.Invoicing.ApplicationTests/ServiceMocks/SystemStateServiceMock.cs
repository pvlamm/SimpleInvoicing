namespace TransDev.Invoicing.ApplicationTests.ServiceMocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class SystemStateServiceMock : ISystemStateService
{
    public Task<SystemState> GetSystemStateByIdAsync(string id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemState>> GetSystemStatesAsync(CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemState>> SearchStatesByIdAsync(string id, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemState>> SearchStatesByNameAsync(string name, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SystemStateExistsById(string id, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
