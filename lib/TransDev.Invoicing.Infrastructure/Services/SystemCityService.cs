namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class SystemCityService : ISystemCityService
{
    public Task<bool> CityExistsAsync(string name, string stateId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SystemCity> CreateNewCityAsync(string name, string stateId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemCity>> GetCitiesByStateIdAsync(string stateId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<SystemCity> GetCityByNameAndStateAsync(string name, string stateId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemCity>> SearchCitiesByNameAndStateIdAsync(string partialName, string stateId, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
