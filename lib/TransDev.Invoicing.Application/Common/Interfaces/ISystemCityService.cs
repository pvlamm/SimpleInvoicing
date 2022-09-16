namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemCityService
{
    Task<SystemCity> GetCityByNameAndStateAsync(string name, string stateId, CancellationToken token);
    Task<bool> CityExistsAsync(string name, string stateId, CancellationToken cancellationToken);
    Task<SystemCity> CreateNewCityAsync(string name, string stateId, CancellationToken token);
    Task<IEnumerable<SystemCity>> GetCitiesByStateIdAsync(string stateId, CancellationToken token);
    /// <summary>
    /// City Lookup
    /// </summary>
    /// <param name="partialName">Not Required, can be partial or complete</param>
    /// <param name="stateId">Not Required, can be partial or complete 2-letter Id</param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<IEnumerable<SystemCity>> SearchCitiesByNameAndStateIdAsync(string partialName, string stateId, CancellationToken token);
}
