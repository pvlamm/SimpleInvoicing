namespace TransDev.Invoicing.Application.Client.Commands;

using System;

using FluentAssertions.Execution;

using FluentValidation;
using FluentValidation.Results;

using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public const string Message_InvalidPrimaryContact = "The Primary Contact property is invalid";
    public const string Message_InvalidBillingContact = "The Billing Contact property is invalid";
    public const string Message_InvalidPrimaryAddress = "The Primary Address property is invalid";
    public const string Message_InvalidBillingAddress = "The Billing Address property is invalid";
    public const string Message_InvalidCompanyName = "The Company Name field is invalid";
    public const string Message_CompanyNameAlreadyExists = "The Chosen Name already exists";

    public const string Message_InvalidFirstName = "First Name must be supplied";
    public const string Message_InvalidLastName = "Last Name must be supplied";
    public const string Message_InvalidEmailAddress = "Must provide a valid Email Address";

    public const string Message_MinimumLength = "Must be at least 2 characters long";

    private readonly IClientService _clientService;
    public CreateClientValidator(IClientService clientService)
    {
        _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));

        RuleFor(x => x.PrimaryContact.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Message_InvalidFirstName)
            .MinimumLength(2)
            .WithMessage(Message_MinimumLength);

        RuleFor(x => x.BillingContact.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Message_InvalidFirstName)
            .MinimumLength(2)
            .WithMessage(Message_MinimumLength);

        RuleFor(x => x.PrimaryContact.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Message_InvalidLastName)
            .MinimumLength(2)
            .WithMessage(Message_MinimumLength);

        RuleFor(x => x.BillingContact.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(Message_InvalidLastName)
            .MinimumLength(2)
            .WithMessage(Message_MinimumLength);

        RuleFor(x => x.PrimaryContact.EmailAddress)
            .EmailAddress()
            .WithMessage(Message_InvalidEmailAddress);

        RuleFor(x => x.BillingContact.EmailAddress)
            .EmailAddress()
            .WithMessage(Message_InvalidEmailAddress);

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


    protected override bool PreValidate(ValidationContext<CreateClientCommand> context, ValidationResult result)
    {
        if (context.InstanceToValidate == null)
        {
            context.AddFailure(new ValidationFailure("CreateClient", Message_InvalidPrimaryContact));
            return false;
        }

        if (context.InstanceToValidate.PrimaryContact == null)
        {
            context.AddFailure(new ValidationFailure("PrimaryContact", Message_InvalidPrimaryContact));
            return false;
        }
        if (context.InstanceToValidate.BillingContact == null) { 
            context.AddFailure(new ValidationFailure("BillingContact", Message_InvalidBillingContact));
            return false;
        }
        if (context.InstanceToValidate.PrimaryAddress == null) { 
            context.AddFailure(new ValidationFailure("PrimaryAddress", Message_InvalidPrimaryAddress));
            return false;
        }

        if (context.InstanceToValidate.BillingAddress == null) { 
            context.AddFailure(new ValidationFailure("BillingAddress", Message_InvalidBillingAddress));
            return false;
        }

        return true;
    }
}
