namespace TransDev.Invoicing.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

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

        public async Task<IEnumerable<Invoice>> GetInvoicesByClientIdAsync(int clientId, CancellationToken token = default)
        {
            var results = await _context
                .Invoices
                .Where(x => x.ClientId == clientId)
                .ToListAsync(token);
            return results;
        }

        public async Task<bool> InvoiceExistsAsync(int invoiceId, CancellationToken token = default)
        {
            return await _context.InvoiceDetails.AnyAsync(x => x.Id == invoiceId, token);
        }

        public async Task<bool> PaymentTermExistsAsync(byte paymentTermId, CancellationToken token = default)
        {
            return await _context.SystemPaymentTerms.AnyAsync(x => x.Id == paymentTermId, token);
        }

        public Task<bool> ProcessPendingInvoicesAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StatusExistsAsync(byte invoiceStatusId, CancellationToken token = default)
        {
            return await _context.SystemInvoiceStatuses.AnyAsync(x => x.Id == invoiceStatusId, token);
        }

        public Task<bool> UpdateInvoiceAsync(Invoice invoice, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateInvoiceStatusAsync(int invoiceId, SystemInvoiceStatus status, CancellationToken token = default)
        {
            var user = _authenticationService.GetCurrentUser();
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
