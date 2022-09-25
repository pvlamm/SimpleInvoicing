namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using Microsoft.EntityFrameworkCore;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class SystemCityService : ISystemCityService
{
    IApplicationDbContext _context;

    public SystemCityService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> CityExistsAsync(string name, string stateId, CancellationToken token)
    {
        var query = _context
            .SystemCities
            .Where(
            city => city.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase));

        if (!string.IsNullOrWhiteSpace(stateId) && stateId.Length > 0)
            query = query.Where(city => city.SystemStateId == stateId);

        return await query.AnyAsync(token);
    }

    public async Task<bool> CityExistsAsync(int id, CancellationToken token)
    {
        return await _context
            .SystemCities
            .AnyAsync(city => city.Id == id, token);
    }

    public async Task<SystemCity> GetCityByIdAsync(int id, CancellationToken token)
    {
        return await _context
            .SystemCities.FirstOrDefaultAsync(city => city.Id == id, token);
    }

    public async Task<SystemCity> CreateNewCityAsync(string name, string stateId, CancellationToken token)
    {
        var city = new SystemCity
        {
            Name = name,
            SystemStateId = stateId
        };

        await _context.SystemCities.AddAsync(city, token);
        await _context.SaveChangesAsync(token);

        return city;

    }

    public async Task<IEnumerable<SystemCity>> GetCitiesByStateIdAsync(string stateId, CancellationToken token)
    {
        return await _context
            .SystemCities
            .Where(city => city.SystemStateId == stateId)
            .ToListAsync(token);
    }

    public async Task<SystemCity> GetCityByNameAndStateAsync(string name, string stateId, CancellationToken token)
    {
        return await _context
            .SystemCities
            .FirstAsync(city =>
                city.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)
                && city.SystemStateId == stateId, token);
    }

    public async Task<IEnumerable<SystemCity>> SearchCitiesByNameAndStateIdAsync(string partialName, string stateId, CancellationToken token)
    {
        return await _context
        .SystemCities
        .Where(city =>
            city.Name.Contains(partialName, StringComparison.InvariantCultureIgnoreCase))
        .ToListAsync(token);

    }
}
