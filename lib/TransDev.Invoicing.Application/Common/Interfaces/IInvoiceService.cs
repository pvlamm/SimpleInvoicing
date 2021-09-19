using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransDev.Invoicing.Domain.Entities;

namespace TransDev.Invoicing.Application.Common.Interfaces
{
    public interface IInvoiceService
    {
        Task<Invoice> GetInvoiceByPublicId(Guid publicId);
    }
}
