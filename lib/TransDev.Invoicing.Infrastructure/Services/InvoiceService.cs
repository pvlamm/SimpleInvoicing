namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Azure;

    using Microsoft.EntityFrameworkCore;

    using TransDev.Invoicing.Application.Common.Interfaces;
    using TransDev.Invoicing.Domain.Entities;

    public class InvoiceService : IInvoiceService
    {
        private readonly IApplicationDbContext _context;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTimeService _dateTimeService;

        public InvoiceService(IApplicationDbContext context, IAuthenticationService authenticationService, IDateTimeService dateTimeService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authenticationService = authenticationService 
                ?? throw new ArgumentNullException(nameof(authenticationService));
            _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));

        }
        public IQueryable<Invoice> Invoices { get; }

        public async Task<Guid> CreateInvoiceAsync(Invoice invoice, CancellationToken token = default)
        {
            await _context.Invoices.AddAsync(invoice, token);
            await _context.SaveChangesAsync(token);

            return invoice.PublicId;
        }

        public async Task<IEnumerable<Invoice>> GetActiveInvoicesByClientIdAsync(int clientId, CancellationToken token = default)
        {
            var results = await _context
                .Invoices
                .Where(x => x.ClientId == clientId)
                .ToListAsync(token);
            return results;
        }

        public async Task<Invoice> GetInvoiceByInvoiceIdAsync(int invoiceId, CancellationToken token = default)
        {
            var result = await _context
                .Invoices
                .Where(x => x.Id == invoiceId)
                .SingleOrDefaultAsync(token);
            return result;
        }

        public async Task<Invoice> GetInvoiceByPublicIdAsync(Guid publicId, CancellationToken token = default)
        {
            var invoiceStub = await _context.Invoices
                .Select(x => new { x.Id, x.PublicId })
                .SingleAsync(x => x.PublicId == publicId, token);

            return await GetInvoiceByInvoiceIdAsync(invoiceStub.Id, token);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByClientIdAsync(int clientId, CancellationToken token = default)
        {
            var results = await _context
                .Invoices
                .Where(x => x.ClientId == clientId)
                .ToListAsync(token);
            return results;
        }

        public bool InvoiceExists(Guid publicId)
        {
            return _context.Invoices.Any(x => x.PublicId == publicId);
        }

        public async Task<bool> InvoiceExistsAsync(int invoiceId, CancellationToken token = default)
        {
            return await _context.InvoiceDetails.AnyAsync(x => x.Id == invoiceId, token);
        }

        public async Task<bool> InvoiceExistsAsync(Guid publicId, CancellationToken token = default)
        {
            return await _context.Invoices.AnyAsync(x => x.PublicId == publicId, token);
        }

        public async Task<bool> PaymentTermExistsAsync(byte paymentTermId, CancellationToken token = default)
        {
            return await _context.SystemPaymentTerms.AnyAsync(x => x.Id == paymentTermId, token);
        }

        public Task<bool> ProcessPendingInvoicesAsync(CancellationToken token = default)
        {
            // update status of Pending Invoices to Processed
            // post message/email notifying of Due Invoices
            // 
            throw new NotImplementedException();
        }

        public async Task<bool> StatusExistsAsync(byte invoiceStatusId, CancellationToken token = default)
        {
            return await _context.SystemInvoiceStatuses.AnyAsync(x => x.Id == invoiceStatusId, token);
        }

        public async Task<bool> UpdateInvoiceAsync(Invoice invoice, CancellationToken token = default)
        {
            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync(token);
            return true;
        }

        public async Task<bool> UpdateInvoiceStatusAsync(int invoiceId, SystemInvoiceStatus status, CancellationToken token = default)
        {
            var user = await _authenticationService.GetCurrentUserAsync();
            var invoice = await _context.Invoices.FindAsync(invoiceId, token);

            var currentInvoiceStatus = await _context.InvoiceStatusHistories
                .SingleOrDefaultAsync(x => x.ParentId == invoiceId 
                    && x.UpdatedAuditTrailId == null, token);

            var auditTrail = new AuditTrail
            {
                UserId = user.Id,
                CreatedDate = _dateTimeService.Now,
                Note = $"Invoice {invoice.Number} Status Update"
            };

            try
            {
                await _context.BeginTransactionAsync();
                currentInvoiceStatus.UpdatedAuditTrail = auditTrail;
                await _context.InvoiceStatusHistories.AddAsync(new InvoiceStatusHistory
                {
                    AuditTrail = auditTrail,
                    Status = status,
                    Parent = invoice,
                    UpdatedAuditTrailId = null
                });
                await _context.CommitTransactionAsync();
                return true;
            }
            catch
            {
                _context.RollbackTransaction();
                return false;
            }
        }
    }
}
