namespace TransDev.Invoicing.Application.Account.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class CreateAccountCommand : IRequest<Guid>
{
    public SystemUserDto AccountOwner { get; set; }
    public string AccountName { get; set; }

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
        _accountService.CreateAccountAsync(request.AccountName, "", cancellationToken);
        _
        throw new NotImplementedException();
    }
}
