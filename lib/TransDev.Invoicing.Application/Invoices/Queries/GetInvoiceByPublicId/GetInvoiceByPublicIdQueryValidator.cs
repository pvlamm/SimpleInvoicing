namespace TransDev.Invoicing.Application.Invoices.Queries;

using System;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class GetInvoiceByPublicIdQueryValidator : AbstractValidator<GetInvoiceByPublicIdQuery>
{
    private const string ERROR_EMPTY_PUBLICID = "Empty PublicIds are not allowed";
    private const string ERROR_INVOICE_DOES_NOT_EXIST = "Id Does Not Exist";

    private readonly IInvoiceService _invoiceService;
    public GetInvoiceByPublicIdQueryValidator(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));

        RuleFor(query => query.PublicId)
            .NotEmpty()
            .WithMessage(ERROR_EMPTY_PUBLICID)
            .Must(_invoiceService.InvoiceExists)
            .WithMessage(ERROR_INVOICE_DOES_NOT_EXIST);
    }
}
