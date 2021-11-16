using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Infrastructure.Services;

public class ItemService : IItemService
{
    private readonly IApplicationDbContext _context;

    public ItemService(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Task DeleteItemAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItemByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItemByItemIdAsync(long ItemId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Item>> GetItemByItemIdAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Item>> ItemLookup(string searchString, int pageSize, int page, bool ActiveOnly = true)
    {
        List<Item> itemHistories = new List<Item>();
        itemHistories.Add(new Item()
        {
            Description = "Labor Item/Basic",
            Price = 7500,
            Code = "Labor",
            Id = 1,
            Type = Domain.Enums.ItemType.Labor
        });
        itemHistories.Add(new Item()
        {
            Description = "Late Night On Call",
            Price = 17500,
            Code = "LaborE",
            Id = 2,
            Type = Domain.Enums.ItemType.Labor
        });
        itemHistories.Add(new Item()
        {
            Description = "Maintanence Services",
            Price = 5000,
            Code = "LaborM",
            Id = 3,
            Type = Domain.Enums.ItemType.Labor
        });

        return await Task.FromResult(itemHistories);
    }

    public Task<Item> SaveChangesToItemSaveAsync(Item Item)
    {
        throw new NotImplementedException();
    }
}
