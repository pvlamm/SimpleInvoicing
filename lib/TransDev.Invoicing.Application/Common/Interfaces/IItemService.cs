namespace TransDev.Invoicing.Application.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TransDev.Invoicing.Domain.Entities;

public interface IItemService
{
    Task<ItemHistory> SaveChangesToItemSaveAsync(ItemHistory itemHistory, CancellationToken token);
    Task DeleteItemAsync(int itemId, CancellationToken token);

    Task<ItemHistory> GetItemByCodeAsync(string code, CancellationToken token);
    Task<ItemHistory> GetItemByItemHistoryIdAsync(long itemHistoryId, CancellationToken token);

    Task<ICollection<ItemHistory>> GetItemHistoryByCodeAsync(string code, CancellationToken token);
    Task<ICollection<ItemHistory>> GetItemHistoryByItemIdAsync(int itemId, CancellationToken token);
    /// <summary>
    /// Returns Active only Items by default lookup
    /// </summary>
    /// <param name="searchString">Search part for fuzzy lookup</param>
    /// <returns>List of ItemHistory</returns>
    Task<ICollection<ItemHistory>> ItemLookupAsync(string searchString, int pageSize, int page, bool ActiveOnly = true, CancellationToken token = default);
}
