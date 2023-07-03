namespace TransDev.Invoicing.Application.Client.Queries;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class GetActiveClientsQuery : PaginationBase, IRequest<GetActiveClientsResponse>
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
        var activeClients = await _clientService.GetActiveClientsAsync(token);
        var clientDtos = activeClients
            .Select(client => new SearchClientDto(client)).ToArray();

        return new GetActiveClientsResponse
        {
            Success = true,
            Clients = clientDtos
        };

    }
}
