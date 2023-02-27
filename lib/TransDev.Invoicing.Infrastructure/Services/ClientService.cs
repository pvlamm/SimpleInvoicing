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
using TransDev.Invoicing.Domain.Enums;

public class ClientService : IClientService
{
    IApplicationDbContext _context;
    IDateTimeService _dateTime;
    ISystemAddressService _systemAddress;

    public ClientService(IApplicationDbContext context, IDateTimeService dateTime, ISystemAddressService systemAddress)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        _systemAddress = systemAddress ?? throw new ArgumentNullException(nameof(systemAddress));
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
                .ThenInclude(contact => contact.History)
                    .Where(history => history.UpdatedAuditTrailId == null)
            .Include(history => history.PrimaryBillingContact)
                .ThenInclude(contact => contact.History)
                    .Where(history => history.UpdatedAuditTrailId == null)
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

    public async Task CreateClientAsync(Client client, CancellationToken token)
    {
        var history = client.History.First();

        history.PrimaryAddress = await CreateOrSetSystemAddressAsync(history.PrimaryAddress, token);
        history.BillingAddress = await CreateOrSetSystemAddressAsync(history.BillingAddress, token);

        await _context.Clients.AddAsync(client, token);
        await _context.SaveChangesAsync(token);
    }

    public async Task CreateClientAsync(ClientType clientType, ClientHistory clientHistory, 
        ContactHistory primaryContactHistory, ContactHistory billingContactHistory, 
        SystemAddress primaryAddress, SystemAddress billingAddress, CancellationToken token)
    {
        try
        {
            await _context.BeginTransactionAsync();

            var auditTrail = new AuditTrail
            {
                CreatedDate = _dateTime.Now,
                Note = "Creating Client"
            };

            await _context.AuditTrails.AddAsync(auditTrail);

            clientHistory.AuditTrail = auditTrail;
            primaryContactHistory.AuditTrail = auditTrail;
            billingContactHistory.AuditTrail = auditTrail;

            primaryAddress = await CreateOrSetSystemAddressAsync(primaryAddress, token);
            billingAddress = await CreateOrSetSystemAddressAsync(billingAddress, token);

            primaryContactHistory.Address = primaryAddress;
            billingContactHistory.Address = billingAddress;

            clientHistory.PrimaryAddress = primaryAddress;
            clientHistory.BillingAddress = billingAddress;

            var client = new Client { ClientType = clientType };
            var primaryContact = new Contact { Client = client };
            var billingContact = new Contact { Client = client };

            await _context.Clients.AddAsync(client, token);

            clientHistory.PrimaryContact = primaryContact;
            clientHistory.PrimaryBillingContact = primaryContact;

            primaryContactHistory.Parent = primaryContact;
            billingContactHistory.Parent = primaryContact;

            await _context.ContactHistory.AddAsync(primaryContactHistory, token);

            if (primaryContactHistory != billingContactHistory)
            {
                clientHistory.PrimaryBillingContact = billingContact;
                billingContactHistory.Parent = billingContact;
            }

            await _context.ContactHistory.AddAsync(billingContactHistory, token);

            clientHistory.Parent = client;
            clientHistory.PrimaryAddress = primaryAddress;
            clientHistory.BillingAddress = billingAddress;

            await _context.ClientHistory.AddAsync(clientHistory, token);
            await _context.SaveChangesAsync(token);
            await _context.CommitTransactionAsync();
        }
        catch
        {
            _context.RollbackTransaction();
        }
    }

    private async Task<SystemAddress> CreateOrSetSystemAddressAsync(SystemAddress address, CancellationToken token)
    {
        if (await _systemAddress.AddressExistsAsync(address.Address, address.City, address.SystemStateId, address.ZipCode, token))
        {
            return (await _systemAddress
                .SearchAddressAsync(address.Address, address.City, address.SystemStateId, address.ZipCode, token)).First();
        }
        else
        {
            return await _systemAddress.CreateSystemAddressAsync(address.Address, address.City, address.SystemStateId, address.ZipCode, token);
        }
    }
}
