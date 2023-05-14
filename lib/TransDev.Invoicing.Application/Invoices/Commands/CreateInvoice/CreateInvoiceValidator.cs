namespace TransDev.Invoicing.Application.Invoices.Commands.CreateInvoice;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateInvoiceValidator : AbstractValidator<CreateInvoiceCommand>
{
    private const string ERROR_CLIENT_INACTIVE = "Client is Inactive";
    private const string ERROR_CONTACT_DOES_NOT_EXIST = "Contact does not Exist";
    private const string ERROR_STATUS_DOES_NOT_EXIST = "Invoice Status does not Exist";
    private const string ERROR_PAYMENT_TERM_DOES_NOT_EXIST = "Payment Term does not Exist";

    public CreateInvoiceValidator(IClientService clientService, IContactService contactService, IInvoiceService invoiceService)
    {
        RuleFor(x => x.ClientId)
            .MustAsync(clientService.ClientIsActiveAsync)
            .WithMessage(ERROR_CLIENT_INACTIVE);

        RuleFor(x => x.ContactId)
            .MustAsync(contactService.ContactExists)
            .WithMessage(ERROR_CONTACT_DOES_NOT_EXIST);

        RuleFor(x => x.SystemInvoiceStatusId)
            .MustAsync(invoiceService.StatusExistsAsync)
            .WithMessage(ERROR_STATUS_DOES_NOT_EXIST);

        RuleFor(x => x.SystemPaymentTermId)
            .MustAsync(invoiceService.PaymentTermExistsAsync)
            .WithMessage(ERROR_PAYMENT_TERM_DOES_NOT_EXIST);

    }
}
