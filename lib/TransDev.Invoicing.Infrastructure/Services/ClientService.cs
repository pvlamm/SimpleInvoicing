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
    IApplicationDbContext _context;
    IDateTimeService _dateTime;

    public ClientService(IApplicationDbContext context, IDateTimeService dateTime)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
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

    public async Task<ClientHistory> CreateClientAsync(ClientHistory history, CancellationToken token)
    {
        await _context.ClientHistory.AddAsync(history, token);
        await _context.SaveChangesAsync(token);

        return history;
    }

    public async Task<bool> ClientIsActiveAsync(int clientId, CancellationToken token)
    {
        return await _context
            .ClientHistory
            .AnyAsync(client => 
                client.ParentId == clientId 
                && client.UpdatedAuditTrailId == null 
                && client.IsActive == true);
    }

    public async Task<bool> UpdateClientAsync(ClientHistory clientHistory, CancellationToken token)
    {
        var clientId = clientHistory.ParentId;
        var auditTrail = new AuditTrail
        {
            CreatedDate = _dateTime.Now,
            Note = "Updating Client History"
        };

        var currentHistory = await _context
            .ClientHistory
            .FirstOrDefaultAsync(client =>
                client.ParentId == clientId
                && client.UpdatedAuditTrailId == null, token);

        clientHistory.AuditTrail = auditTrail;
        currentHistory.UpdatedAuditTrail = auditTrail;

        await _context.ClientHistory.AddAsync(clientHistory, token);

        return await _context.SaveChangesAsync(token) > 0;
    }
}
