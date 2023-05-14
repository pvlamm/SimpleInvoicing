namespace TransDev.Invoicing.Application.Common.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InvoiceDetailDto
{
    public long ItemHistoryId { get; set; }
    public decimal Cost { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
