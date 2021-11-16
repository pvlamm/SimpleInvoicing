using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Application.Common.Interfaces;

public interface IItemService
{
    Task<Item> SaveChangesToItemSaveAsync(Item item);
    Task DeleteItemAsync(int itemId);

    Task<Item> GetItemByCodeAsync(string code);
    Task<Item> GetItemByItemIdAsync(long itemId);

    /// <summary>
    /// Returns Active only Items by default lookup
    /// </summary>
    /// <param name="searchString">Search part for fuzzy lookup</param>
    /// <returns>List of Item</returns>
    Task<ICollection<Item>> ItemLookup(string searchString, int pageSize, int page, bool ActiveOnly = true);
}
