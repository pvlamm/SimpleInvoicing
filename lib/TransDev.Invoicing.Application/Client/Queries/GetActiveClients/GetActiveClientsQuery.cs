namespace TransDev.Invoicing.Application.Client.Queries;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class GetActiveClientsQuery : IRequest<GetActiveClientsResponse>
{

}

public class GetActiveClientsQueryHandler : IRequestHandler<GetActiveClientsQuery, GetActiveClientsResponse>
{
    readonly IClientService _clientService;

    public GetActiveClientsQueryHandler(IClientService clientServices)
    {
        _clientService = clientServices ?? throw new ArgumentNullException(nameof(clientServices));
    }

    public async Task<GetActiveClientsResponse> Handle(GetActiveClientsQuery request, CancellationToken token)
    {
        //var activeClients = await _clientService.GetActiveClientsAsync(token);
        //var clientDtos = activeClients
        //    .Select(client => new SearchClientDto(client)).ToArray();

        return new GetActiveClientsResponse
        {
            Success = true,
            Clients = new SearchClientDto[]
            {
                new SearchClientDto
                {
                    Name = "Fred",
                    PrimaryContactEmail = "fred@scotts.com",
                    PrimaryContactPhone = "704.555.5555"
                },
                new SearchClientDto
                {
                    Name = "Mavis",
                    PrimaryContactEmail = "mavis@cars.com",
                    PrimaryContactPhone = "919.888.8888"
                },
                new SearchClientDto
                {
                    Name = "Clubber Lang",
                    PrimaryContactEmail = "clubber.lang@boxingday.com",
                    PrimaryContactPhone = "828.333.3333"
                },
            }
        };

    }
}
