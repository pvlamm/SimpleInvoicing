namespace TransDev.Invoicing.Application.Account.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateAccountCommand : IRequest<Guid>
{
    public string EmailAddress  { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public AddressDto PrimaryAddress { get; set; }
    public AddressDto BillingAddress { get; set; }

}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IAccountService _accountService;
    
    public CreateAccountCommandHandler(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }

    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        return await _accountService.CreateAccountAsync(request.Name, request.Password, cancellationToken);
    }
}
