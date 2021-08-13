using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Enums;

namespace TransDev.Invoicing.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public ItemType Type { get; set; }
        public ICollection<ItemHistory> ItemHistories { get; set; } = new HashSet<ItemHistory>();
    }
}
