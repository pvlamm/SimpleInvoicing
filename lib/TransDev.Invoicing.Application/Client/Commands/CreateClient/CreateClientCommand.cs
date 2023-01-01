namespace TransDev.Invoicing.Application.Client.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class CreateClientCommand : IRequest<CreateClientResponse>
{
    NewClientDto ClientDto { get; set; }
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
        ClientHistory clientHistory = new ClientHistory();

        // Convert request.ClientDto to clientHistory;

        clientHistory = await _clientService.CreateClientAsync(clientHistory, token);

        ClientDto client = new ClientDto(clientHistory);

        // Convert ClientHistory to ClientDto

        return new CreateClientResponse
        {
            Success = clientHistory.Id > 0,
            Client = client
        };
    }
}
