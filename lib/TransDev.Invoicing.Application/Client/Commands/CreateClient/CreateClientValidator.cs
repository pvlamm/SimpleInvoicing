namespace TransDev.Invoicing.Application.Client.Commands;

using System;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public const string Message_InvalidPrimaryContact = "The Primary Contact property is invalid";
    public const string Message_InvalidBillingContact = "The Billing Contact property is invalid";
    public const string Message_InvalidPrimaryAddress = "The Primary Address property is invalid";
    public const string Message_InvalidBillingAddress = "The Billing Address property is invalid";
    public const string Message_InvalidCompanyName = "The Company Name field is invalid";
    public const string Message_CompanyNameAlreadyExists = "The Chosen Name already exists";

    private readonly IClientService _clientService;
    public CreateClientValidator(IClientService clientService)
    {
        _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));

        RuleFor(x => x.PrimaryContact)
            .NotNull()
            .WithMessage(Message_InvalidPrimaryContact);

        RuleFor(x => x.BillingContact)
            .NotNull()
            .WithMessage(Message_InvalidBillingContact);

        RuleFor(x => x.PrimaryAddress)
            .NotNull()
            .WithMessage(Message_InvalidPrimaryAddress);

        RuleFor(x => x.BillingAddress)
            .NotNull()
            .WithMessage(Message_InvalidBillingAddress);

        RuleFor(x => x.CompanyName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Message_InvalidCompanyName)
            .MustAsync(async (companyName, cancellation) =>
            {
                return !(await _clientService.ClientExistsAsync(companyName, cancellation));
            })
            .WithMessage(Message_CompanyNameAlreadyExists);

    }
}
