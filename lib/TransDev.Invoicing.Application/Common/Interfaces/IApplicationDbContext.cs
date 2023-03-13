namespace TransDev.Invoicing.Application.Common.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface IApplicationDbContext
{
    DbSet<AuditTrail> AuditTrails { get; set; }
    DbSet<Client> Clients { get; set; }
    DbSet<ClientHistory> ClientHistory { get; set; }
    DbSet<Contact> Contacts { get; set; }
    DbSet<ContactHistory> ContactHistory { get; set; }
    DbSet<Item> Items { get; set; }
    DbSet<ItemHistory> ItemHistories { get; set; }
    DbSet<SystemAddress> SystemAddresses { get; set; }
    DbSet<SystemState> SystemStates { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    DbSet<InvoiceStatusHistory> InvoiceStatusHistories { get; set; }
    DbSet<SystemInvoiceStatus> SystemInvoiceStatuses { get; set; }

    IModel Model { get; }

    Task<int> SaveChangesAsync(CancellationToken token = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    void RollbackTransaction();
}
