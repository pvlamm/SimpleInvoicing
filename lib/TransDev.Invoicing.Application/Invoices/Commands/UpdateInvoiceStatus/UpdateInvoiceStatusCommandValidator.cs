namespace TransDev.Invoicing.Application.Invoices.Commands;

using System;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class UpdateInvoiceStatusCommandValidator : AbstractValidator<UpdateInvoiceStatusCommand>
{
    private readonly IInvoiceService _invoiceService;

    public UpdateInvoiceStatusCommandValidator(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));

        RuleFor(command => command.PublicId)
            .NotEmpty()
            .WithMessage("Public Id is not valid")
            .Must(_invoiceService.InvoiceExists)
            .WithMessage("Invoice Id is invalid");

        RuleFor(command => command.SystemInvoiceStatusId)
            .GreaterThan((byte)0)
            .WithMessage("Must provide a valid Status");
            
    }
}
