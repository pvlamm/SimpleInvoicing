namespace TransDev.Invoicing.Application.Client.Commands;

using FluentValidation;

using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateClientValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClientValidator(IClientService clientService)
    {
        
        // Validate Name

        // Validate ... ?
    }
}
