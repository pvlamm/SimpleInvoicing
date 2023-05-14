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

        public Task<CreateInvoiceResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
