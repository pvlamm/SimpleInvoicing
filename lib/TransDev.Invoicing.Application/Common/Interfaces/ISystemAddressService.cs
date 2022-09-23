namespace TransDev.Invoicing.Application.Common.Interfaces;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface ISystemAddressService
{
    Task<SystemAddress> CreateSystemAddressAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token);
    Task<SystemAddress> CreateSystemAddressAsync(string address, int cityId, string stateId, string zipCode, CancellationToken token);
    Task<bool> AddressExistsAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token);
    Task<SystemAddress> GetSystemAddressById(int addressId, CancellationToken token);
    Task<IEnumerable<SystemAddress>> SearchAddressAsync(string addressPartial, string cityPartial, string stateId, string zipPartial, CancellationToken token);
}