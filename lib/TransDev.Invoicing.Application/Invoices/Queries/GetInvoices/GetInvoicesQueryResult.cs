namespace TransDev.Invoicing.Application.Invoices.Queries.GetInvoices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Application.Common.Dtos;

    public class GetInvoicesQueryResult
    {
        public InvoiceDto[] Invoices { get; set; }
    }
}
