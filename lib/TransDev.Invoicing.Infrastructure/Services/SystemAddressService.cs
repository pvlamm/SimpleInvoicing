namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class SystemAddressService : ISystemAddressService
{
    public Task<bool> AddressExistsAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<SystemAddress> CreateSystemAddressAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<SystemAddress> CreateSystemAddressAsync(string address, int cityId, string stateId, string zipCode, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<SystemAddress> GetSystemAddressById(int addressId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemAddress>> SearchAddressAsync(string addressPartial, string cityPartial, string stateId, string zipPartial, CancellationToken token)
    {
        throw new NotImplementedException();
    }
}
