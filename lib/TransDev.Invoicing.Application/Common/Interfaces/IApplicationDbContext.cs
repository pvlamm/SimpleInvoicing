using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AuditTrail> AuditTrails { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<ItemHistory> ItemHistories { get; set; }

        IModel Model { get; }

        Task<int> SaveChangesAsync(CancellationToken token = default);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}
