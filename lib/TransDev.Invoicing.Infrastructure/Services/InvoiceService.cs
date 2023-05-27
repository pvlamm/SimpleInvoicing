namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Application.Common.Interfaces;
    using TransDev.Invoicing.Domain.Entities;

    internal class InvoiceService : IInvoiceService
    {
        public IQueryable<Invoice> Invoices => throw new NotImplementedException();

        public Task<Guid> CreateInvoiceAsync(Invoice invoice, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetActiveInvoicesByClientIdAsync(int clientId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Invoice> GetInvoiceByInvoiceIdAsync(int invoiceId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetInvoicesByClientIdAsync(int clientId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InvoiceExistsAsync(int invoiceId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PaymentTermExistsAsync(byte paymentTermId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProcessPendingInvoicesAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StatusExistsAsync(byte invoiceStatusId, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvoiceAsync(Invoice invoice, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateInvoiceStatusAsync(int invoiceId, SystemInvoiceStatus status, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
