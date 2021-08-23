using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Infrastructure.Services
{
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

        public async Task<ICollection<ItemHistory>> ItemLookup(string searchString, int pageSize, int page, bool ActiveOnly = true)
        {
            List<ItemHistory> itemHistories = new List<ItemHistory>();
            itemHistories.Add(new ItemHistory() {
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

        public Task<ItemHistory> SaveChangesToItemSaveAsync(ItemHistory itemHistory)
        {
            throw new NotImplementedException();
        }
    }
}
