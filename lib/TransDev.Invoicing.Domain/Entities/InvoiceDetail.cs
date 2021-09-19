using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Domain.Entities
{
    public class InvoiceDetail
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public virtual Invoice Parent { get; set; }
        public short Sequence { get; set; }
        public long ItemHistoryId { get; set; }
        public virtual ItemHistory ItemHistory { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
