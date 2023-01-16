namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemAddressService
{
    /// <summary>
    /// Creates a new SystemAddress entry, if provided City Name does not exist, it will be created
    /// </summary>
    /// <param name="address"></param>
    /// <param name="cityName">If City/State combo does not exist, then it will add this City</param>
    /// <param name="stateId">State Id</param>
    /// <param name="zipCode"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<SystemAddress> CreateSystemAddressAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token);
    /// <summary>
    /// Created SystemAddress entry using the provided cityId
    /// </summary>
    /// <param name="address"></param>
    /// <param name="cityId">Link by City Id</param>
    /// <param name="stateId"></param>
    /// <param name="zipCode"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    Task<SystemAddress> CreateSystemAddressAsync(string address, int cityId, string stateId, string zipCode, CancellationToken token);
    Task<bool> AddressExistsAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token);
    Task<bool> CityExistsAsync(string cityName, string stateId, CancellationToken token);
    Task<bool> StateExistsAsync(string stateId, CancellationToken token);
    Task<SystemAddress> GetSystemAddressById(int addressId, CancellationToken token);
    Task<IEnumerable<SystemAddress>> SearchAddressAsync(string addressPartial, string cityPartial, string stateId, string zipPartial, CancellationToken token);
}