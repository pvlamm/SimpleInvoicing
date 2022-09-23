namespace TransDev.Invoicing.Application.Contact.Commands;

using FluentValidation;

public class CreateContactValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactValidator()
    {
    }
}
