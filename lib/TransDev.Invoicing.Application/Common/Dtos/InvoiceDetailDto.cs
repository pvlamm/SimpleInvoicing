using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Application.Common.Dtos
{
    public class InvoiceDetailDto
    {
        public Guid PublicId { get; set; }
        public ushort SequenceNumber { get; set; }
        public Guid ItemPublidId { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

    }
}
