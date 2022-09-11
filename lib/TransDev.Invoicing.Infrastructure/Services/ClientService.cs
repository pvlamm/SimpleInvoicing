namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class ClientService : IClientService
{
    private IApplicationDbContext _context;
    public ClientService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<bool> ClientExistsAsync(string name, CancellationToken token)
    {
        return await _context
            .ClientHistory
            .AnyAsync(history => 
                history.UpdatedAuditTrailId == null
                && history.Name == name, token);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<IEnumerable<ClientHistory>> GetActiveClientsAsync(CancellationToken token)
    {
        return await _context
            .ClientHistory
            .Include(history => history.AuditTrail)
            .Include(history => history.Parent)
            .Include(history => history.PrimaryAddress)
            .Include(history => history.BillingAddress)
            .Include(history => history.PrimaryContact)
            .Include(history => history.PrimaryBillingContact)
            .Where(history => history.UpdatedAuditTrailId == null)
            .ToListAsync(token);
    }

    public async Task<IEnumerable<ClientHistory>> GetClientHistoryAsync(int clientId, CancellationToken token)
    {
        return await _context
            .ClientHistory
            .Include(history => history.AuditTrail)
            .Include(history => history.Parent)
            .Include(history => history.PrimaryAddress)
            .Include(history => history.BillingAddress)
            .Include(history => history.PrimaryContact)
            .Include(history => history.PrimaryBillingContact)
            .Where(history => history.ParentId == clientId)
            .ToListAsync(token);
    }

}
