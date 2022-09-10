namespace TransDev.Invoicing.Application.Client.Queries.GetActiveClients;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

public class GetActiveClientsQuery : IRequest<GetActiveClientsResponse>
{

}

public class GetActiveClientsQueryHandler : IRequestHandler<GetActiveClientsResponse>
{
    public GetActiveClientsQueryHandler()
    {
    }

    public Task<Unit> Handle(GetActiveClientsResponse request, CancellationToken token)
    {
        throw new System.NotImplementedException();
    }
}
