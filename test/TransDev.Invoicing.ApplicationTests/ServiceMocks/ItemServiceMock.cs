namespace TransDev.Invoicing.ApplicationTests.ServiceMocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class ItemServiceMock : IItemService
{
    public Task DeleteItemAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<ItemHistory> GetItemByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<ItemHistory> GetItemByItemHistoryIdAsync(long itemHistoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ItemHistory>> GetItemHistoryByCodeAsync(string code)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ItemHistory>> GetItemHistoryByItemIdAsync(int itemId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<ItemHistory>> ItemLookup(string searchString, int pageSize, int page, bool ActiveOnly = true)
    {
        throw new NotImplementedException();
    }

    public Task<ItemHistory> SaveChangesToItemSaveAsync(ItemHistory itemHistory)
    {
        throw new NotImplementedException();
    }
}
