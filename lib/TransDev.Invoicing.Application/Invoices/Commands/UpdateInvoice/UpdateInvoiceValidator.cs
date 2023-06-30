namespace TransDev.Invoicing.Application.Invoices.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using FluentValidation;
    using TransDev.Invoicing.Application.Common.Interfaces;

    public class UpdateInvoiceValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public const string ERROR_INVOICE_ID_NOT_FOUND = "Invoice to Update was not found";

        private readonly IInvoiceService _invoiceService;
        public UpdateInvoiceValidator(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));

            RuleFor(x => x.Invoice.PublicId)
                .NotEmpty()
                .Must(_invoiceService.InvoiceExists)
                .WithMessage(ERROR_INVOICE_ID_NOT_FOUND);
        }
    }
}
