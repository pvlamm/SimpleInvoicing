namespace TransDev.Invoicing.Application.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using TransDev.Invoicing.Domain.Entities;

    public interface IInvoiceService
    {
        IQueryable<Invoice> Invoices { get; }
        /// <summary>
        /// Returns Invoice PublicId for success
        /// </summary>
        /// <param name="invoice"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<Guid> CreateInvoiceAsync(Invoice invoice, CancellationToken token = default);
        Task<bool> UpdateInvoiceAsync(Invoice invoice, CancellationToken token = default);
        Task<bool> UpdateInvoiceStatusAsync(int invoiceId, byte systemInvoiceStatusId, CancellationToken token = default);

        Task<IEnumerable<Invoice>> GetActiveInvoicesByClientIdAsync(int clientId, CancellationToken token = default);
        Task<IEnumerable<Invoice>> GetInvoicesByClientIdAsync(int clientId, CancellationToken token = default);
        Task<Invoice> GetInvoiceByInvoiceIdAsync(int invoiceId, CancellationToken token = default);
        Task<Invoice> GetInvoiceByPublicIdAsync(Guid publicId, CancellationToken token = default);
        Task<bool> ProcessPendingInvoicesAsync(CancellationToken token = default);
        Task<bool> InvoiceExistsAsync(int invoiceId, CancellationToken token = default);
        Task<bool> InvoiceExistsAsync(Guid publicId, CancellationToken token = default);
        bool InvoiceExists(Guid publicId);
        Task<bool> StatusExistsAsync(byte invoiceStatusId, CancellationToken token = default);
        Task<bool> PaymentTermExistsAsync(byte paymentTermId, CancellationToken token = default);
    }
}
