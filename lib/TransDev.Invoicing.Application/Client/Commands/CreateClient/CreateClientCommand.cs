namespace TransDev.Invoicing.Application.Client.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;
using TransDev.Invoicing.Domain.Enums;

public class CreateClientCommand : IRequest<CreateClientResponse>
{
    public string CompanyName { get; set; }
    public ContactDto PrimaryContact { get; set; }
    public ContactDto BillingContact { get; set; }
    public AddressDto PrimaryAddress { get; set; }
    public AddressDto BillingAddress { get; set; }

}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
{
    IClientService _clientService;

    public CreateClientCommandHandler(IClientService clientService)
    {
        _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
    }

    public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken token)
    {
        var clientType = ClientType.Commercial;
        var clientHistory = new ClientHistory { Name = request.CompanyName };
        var primaryContact = request.PrimaryContact.ConvertToContactHistory();
        var billingContact = request.BillingContact.ConvertToContactHistory();
        var primaryAddress = request.PrimaryAddress.ConvertToSystemAddress();
        var billingAddress = request.BillingAddress.ConvertToSystemAddress();

        await _clientService.CreateClientAsync(clientType, clientHistory, primaryContact,
            billingContact, primaryAddress, billingAddress, token);

        var clientDto = new ClientDto(clientHistory);

        return new CreateClientResponse
        {
            Success = clientHistory.Id > 0,
            Client = clientDto
        };
    }

}
