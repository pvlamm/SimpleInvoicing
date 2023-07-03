namespace TransDev.Invoicing.Infrastructure.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class ItemService : IItemService
{
    private readonly IApplicationDbContext _context;

    public ItemService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task DeleteItemAsync(int itemId, CancellationToken token)
    {
        var item = await _context.Items.SingleAsync(x => x.Id == itemId, token);
        _context.Items.Remove(item);
        await _context.SaveChangesAsync(token);
    }

    public async Task<ItemHistory> GetItemByCodeAsync(string code, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ItemHistory> GetItemByIdAsync(int itemId, CancellationToken token)
    {
        var item = await _context.ItemHistories
            .Include(x => x.Parent)
            .FirstOrDefaultAsync(x => 
            x.ParentId == itemId && x.UpdatedAuditTrailId == null, token);
        return item;
    }

    public async Task<ItemHistory> GetItemByItemHistoryIdAsync(long itemHistoryId, CancellationToken token)
    {
        return await _context.ItemHistories
                .SingleAsync(x => x.Id ==  itemHistoryId, token);
    }

    public async Task<ICollection<ItemHistory>> GetItemHistoryByCodeAsync(string code, CancellationToken token)
    {
        var item = await _context.Items
            .Select(x => new { x.Id, x.Code })
            .SingleAsync(x => x.Code == code, token);

        return await GetItemHistoryByItemIdAsync(item.Id, token);
    }

    public async Task<ICollection<ItemHistory>> GetItemHistoryByItemIdAsync(int itemId, CancellationToken token)
    {
        return await _context.ItemHistories
            .Where(x => x.ParentId == itemId)
            .OrderBy(x => x.AuditTrailId)
            .ToListAsync(token);
    }

    public bool ItemExists(int itemId)
    {
        return _context.Items.Any(x => x.Id == itemId);
    }

    public async Task<bool> ItemExistsAsync(int itemId, CancellationToken token)
    {
        return await _context.Items.AnyAsync(x => x.Id == itemId, token);
    }

    public async Task<ICollection<ItemHistory>> ItemLookupAsync(string searchString, int pageSize, int page, bool ActiveOnly = true, CancellationToken token = default)
    {
        List<ItemHistory> itemHistories = new List<ItemHistory>();
        itemHistories.Add(new ItemHistory()
        {
            Description = "Labor Item/Basic",
            Price = 7500,
            Parent = new Item
            {
                Code = "Labor",
                Id = 1,
                Type = Domain.Enums.ItemType.Labor
            }
        });
        itemHistories.Add(new ItemHistory()
        {
            Description = "Late Night On Call",
            Price = 17500,
            Parent = new Item
            {
                Code = "LaborE",
                Id = 2,
                Type = Domain.Enums.ItemType.Labor
            }
        });
        itemHistories.Add(new ItemHistory()
        {
            Description = "Maintanence Services",
            Price = 5000,
            Parent = new Item
            {
                Code = "LaborM",
                Id = 3,
                Type = Domain.Enums.ItemType.Labor
            }
        });

        return await Task.FromResult(itemHistories);
    }

    public async Task<ItemHistory> SaveChangesToItemSaveAsync(ItemHistory itemHistory, CancellationToken token)
    {
        var currentItemHistory = await _context.ItemHistories
            .FirstOrDefaultAsync(x => x.ParentId == itemHistory.ParentId, token);

        var auditTrail = new AuditTrail
        {
            Note = "Updating Item History",
            UserId = 1
        };

        currentItemHistory.UpdatedAuditTrail = auditTrail;
        itemHistory.AuditTrail = auditTrail;
        itemHistory.UpdatedAuditTrail = null;

        await _context.ItemHistories.AddAsync(itemHistory,token);
        await _context.SaveChangesAsync(token);

        return itemHistory;
    }
}
