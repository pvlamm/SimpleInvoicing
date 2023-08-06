namespace TransDev.Invoicing.Application.Account.Commands.UpdateAccount;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class UpdateAccountCommand : IRequest<Guid>
{
    public AddressDto MailingAddress { get; set; }
    public AddressDto BillingAddress { get; set; }
}

public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Guid>
{
    private readonly IAccountService _accountService;

    public UpdateAccountCommandHandler(IAccountService accountService)
    {
        _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
    }
    public async Task<Guid> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        return Guid.NewGuid();
    }
}