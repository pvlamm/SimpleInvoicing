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

public class SystemStateService : ISystemStateService
{
    IApplicationDbContext _context;

    public SystemStateService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));

    }

    public async Task<SystemState> GetSystemStateByIdAsync(string id, CancellationToken token)
    {
        return await _context.SystemStates.FirstOrDefaultAsync(state => state.Id == id, token);
    }

    public async Task<IEnumerable<SystemState>> GetSystemStatesAsync(CancellationToken token)
    {
        return await _context.SystemStates.ToListAsync(token);
    }

    public async Task<IEnumerable<SystemState>> SearchStatesByIdAsync(string id, CancellationToken token)
    {
        return await _context
            .SystemStates
            .Where(state =>
                state.Id.Contains(id, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync(token);
    }

    public async Task<IEnumerable<SystemState>> SearchStatesByNameAsync(string name, CancellationToken token)
    {
        return await _context
            .SystemStates
            .Where(state =>
                state.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync(token);
    }

    public async Task<bool> SystemStateExistsById(string id, CancellationToken token)
    {
        return await _context.SystemStates.AnyAsync(state => state.Id == id, token);
    }
}
