namespace TransDev.Invoicing.Application.Invoices.Commands.CreateInvoice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    using TransDev.Invoicing.Application.Common.Dtos;
    using TransDev.Invoicing.Application.Common.Interfaces;
    using TransDev.Invoicing.Domain.Entities;

    public class CreateInvoiceCommand : IRequest<CreateInvoiceResponse>
    {
        public int ClientId { get; set; }
        public int ContactId { get; set; }
        public byte SystemPaymentTermId { get; set; }
        public byte SystemInvoiceStatusId { get; set; }
        public InvoiceDetailDto[] InvoiceDetails { get; set; }
    }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceResponse>
    {
        private readonly IInvoiceService _invoiceService;

        public CreateInvoiceCommandHandler(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
        }

        public async Task<CreateInvoiceResponse> Handle(CreateInvoiceCommand request, 
            CancellationToken cancellationToken)
        {
            var invoice = new Invoice
            {
                SystemPaymentTermId = request.SystemPaymentTermId,
                ClientId = request.ClientId,
                ContactId = request.ContactId,
                DueDate = null,
                Invoiced = null,                
            };

            invoice.PublicId = await _invoiceService.CreateInvoiceAsync(invoice, cancellationToken);

            return new CreateInvoiceResponse
            {
                InvoiceId = invoice.PublicId
            };
        }
    }
}
