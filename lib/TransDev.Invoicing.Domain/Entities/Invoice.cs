using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Enums;

namespace TransDev.Invoicing.Domain.Entities
{
    public class Invoice
    {
        public long Id { get; set; }
        public Guid PublicId { get; set; }
        public long ClientId { get; set; }
        public virtual Client Client { get; set; }
        public InvoiceStatus Status { get; set; }
        public ICollection<InvoiceDetail> Details = new HashSet<InvoiceDetail>();
    }
}
