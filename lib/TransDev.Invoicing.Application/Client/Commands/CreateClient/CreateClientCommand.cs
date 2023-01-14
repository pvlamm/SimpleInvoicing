namespace TransDev.Invoicing.Application.Client.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class CreateClientCommand : IRequest<CreateClientResponse>
{
    public string CompanyName { get; set; }
    public ContactDto PrimaryContact { get; set; }
    public ContactDto BillingContact { get; set; }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CreateClientResponse>
{
    IClientService _clientService;
    IDateTimeService _dateTimeService;

    public CreateClientCommandHandler(IClientService clientService, IDateTimeService dateTimeService)
    {
        _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        _dateTimeService = dateTimeService ?? throw new ArgumentNullException(nameof(dateTimeService));
    }

    public async Task<CreateClientResponse> Handle(CreateClientCommand request, CancellationToken token)
    {
        var message = $"Creating Client {request.CompanyName}";
        if(message.Length > 1024)
        {
            message = message.Substring(0, 1024);
        }

        var auditTrail = new AuditTrail
        {
            CreatedDate = _dateTimeService.Now,
            Note = message
        };

        ClientHistory clientHistory = new ClientHistory();

        clientHistory.AuditTrail = auditTrail;

        var client = new Client
        {
            ClientType = Domain.Enums.ClientType.Commercial
        };

        client.History.Add(clientHistory);

        AddContactRecord(auditTrail, clientHistory.PrimaryContact, request.PrimaryContact);
        AddContactRecord(auditTrail, clientHistory.PrimaryBillingContact, request.BillingContact);

        await _clientService.CreateClientAsync(client, token);

        var clientDto = new ClientDto(clientHistory);

        return new CreateClientResponse
        {
            Success = clientHistory.Id > 0,
            Client = clientDto
        };
    }

    private static void AddContactRecord(AuditTrail auditTrail, Contact contact, ContactDto contactDto)
    {
        var contactHistory = contactDto.ConvertToContactHistory();
        contactHistory.AuditTrail = auditTrail;
        contact.History.Add(contactHistory);
    }
}
