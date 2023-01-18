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
    public AddressDto PrimaryAddress { get; set; }
    public AddressDto BillingAddress { get; set; }

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
        if (message.Length > 1024)
        {
            message = message.Substring(0, 1024);
        }

        request.PrimaryAddress = new AddressDto
        {
            Address = "123 Any St",
            City = "Charlotte",
            State = "NC",
            ZipCode = "28173"
        };

        request.BillingAddress = request.PrimaryAddress;

        var auditTrail = new AuditTrail
        {
            CreatedDate = _dateTimeService.Now,
            Note = message
        };

        ClientHistory clientHistory = new ClientHistory();

        clientHistory.Name = request.CompanyName;
        clientHistory.AuditTrail = auditTrail;

        var client = new Client
        {
            ClientType = Domain.Enums.ClientType.Commercial
        };

        clientHistory.Parent = client;
        client.History.Add(clientHistory);

        clientHistory.PrimaryAddress = new SystemAddress
        {
            Address = request.PrimaryAddress.Address,
            City = request.PrimaryAddress.City,
            SystemStateId = request.PrimaryAddress.State,
            ZipCode = request.PrimaryAddress.ZipCode
        };

        clientHistory.BillingAddress = new SystemAddress
        {
            Address = request.BillingAddress.Address,
            City = request.BillingAddress.City,
            SystemStateId = request.BillingAddress.State,
            ZipCode = request.BillingAddress.ZipCode
        };

        clientHistory.PrimaryContact = new Contact();
        AddContactRecord(auditTrail, client, clientHistory.PrimaryContact, request.PrimaryContact);
        clientHistory.PrimaryBillingContact = new Contact();
        AddContactRecord(auditTrail, client, clientHistory.PrimaryBillingContact, request.BillingContact);

        await _clientService.CreateClientAsync(client, token);

        var clientDto = new ClientDto(clientHistory);

        return new CreateClientResponse
        {
            Success = clientHistory.Id > 0,
            Client = clientDto
        };
    }

    private static void AddContactRecord(AuditTrail auditTrail, Client client, Contact contact, ContactDto contactDto)
    {
        var contactHistory = contactDto.ConvertToContactHistory();

        client.Contacts.Add(contact);
        contact.Client = client;

        contactHistory.Parent = contact;
        contactHistory.AuditTrail = auditTrail;
        contact.History.Add(contactHistory);
    }
}
