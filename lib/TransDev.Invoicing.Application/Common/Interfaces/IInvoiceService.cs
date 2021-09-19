using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Domain.Enums;

namespace TransDev.Invoicing.Application.Common.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoiceByPublicId(Guid publicId);
        Task<bool> CreateInvoice(Invoice invoice);
        Task<bool> UpdateInvoiceStatus(long invoiceId, InvoiceStatus status);

    }
}
