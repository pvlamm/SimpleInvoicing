namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class SystemAddressService : ISystemAddressService
{
    IApplicationDbContext _context;
    ISystemStateService _systemStateService;

    public SystemAddressService(IApplicationDbContext context, ISystemStateService systemStateService)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _systemStateService= systemStateService ?? throw new ArgumentNullException(nameof(systemStateService));

    }

    public async Task<bool> AddressExistsAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token)
    {
        return await _context
            .SystemAddresses
            .AnyAsync(addr =>
                addr.Address == address
                && addr.City == cityName
                && addr.SystemStateId == stateId
                && addr.ZipCode == zipCode, token);
    }

    public async Task<bool> StateExistsAsync(string stateId, CancellationToken token)
    {
        return await _systemStateService.SystemStateExistsById(stateId, token);
    }
    public async Task<SystemAddress> CreateSystemAddressAsync(string address, string cityName, string stateId, string zipCode, CancellationToken token)
    {
        var addr = new SystemAddress
        {
            Address = address,
            City = cityName,
            SystemStateId = stateId,
            ZipCode = zipCode,
        };

        await _context.SystemAddresses.AddAsync(addr, token);
        await _context.SaveChangesAsync(token);

        return addr;
    }

    public async Task<SystemAddress> GetSystemAddressById(int addressId, CancellationToken token)
    {
        return await _context
            .SystemAddresses
            .FirstOrDefaultAsync(address => address.Id == addressId, token);
    }

    /// <summary>
    /// This will not work as currently written - Fix
    /// </summary>
    /// <param name="addressPartial"></param>
    /// <param name="cityPartial"></param>
    /// <param name="stateId"></param>
    /// <param name="zipPartial"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<SystemAddress>> SearchAddressAsync(string addressPartial, string cityPartial, string stateId, string zipPartial, CancellationToken token)
    {
        var query = _context
            .SystemAddresses
            .Include(addr => addr.City)
            .Include(addr => addr.State)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(addressPartial) && addressPartial.Length > 0)
        {
            query.Where(addr => 
                addr.Address.Contains(addressPartial, 
                StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(cityPartial) && cityPartial.Length > 0)
        {
            query.Where(addr =>
                addr.City.Contains(cityPartial,
                StringComparison.InvariantCultureIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(stateId) && stateId.Length > 0)
        {
            query.Where(addr => addr.SystemStateId == stateId);
        }

        if (!string.IsNullOrWhiteSpace(zipPartial) && zipPartial.Length > 0)
        {
            query.Where(addr =>
                addr.ZipCode.Contains(zipPartial,
                StringComparison.InvariantCultureIgnoreCase));
        }

        return await query.ToListAsync(token);
    }
}
