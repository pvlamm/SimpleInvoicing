using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Application.Common.Interfaces
{
    public interface IItemService
    {
        Task<ItemHistory> SaveChangesToItemSaveAsync(ItemHistory itemHistory);
        Task DeleteItemAsync(int itemId);

        Task<ItemHistory> GetItemByCodeAsync(string code);
        Task<ItemHistory> GetItemByItemHistoryIdAsync(long itemHistoryId);

        Task<ICollection<ItemHistory>> GetItemHistoryByCodeAsync(string code);
        Task<ICollection<ItemHistory>> GetItemHistoryByItemIdAsync(int itemId);

        /// <summary>
        /// Returns Active only Items by default lookup
        /// </summary>
        /// <param name="searchString">Search part for fuzzy lookup</param>
        /// <returns>List of ItemHistory</returns>
        Task<ICollection<ItemHistory>> ItemLookup(string searchString, bool ActiveOnly = true);
    }
}
