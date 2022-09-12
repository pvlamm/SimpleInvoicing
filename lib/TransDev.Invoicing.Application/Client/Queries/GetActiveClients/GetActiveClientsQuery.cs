namespace TransDev.Invoicing.Application.Client.Queries;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

public class GetActiveClientsQuery : IRequest<GetActiveClientsResponse>
{

}

public class GetActiveClientsQueryHandler : IRequestHandler<GetActiveClientsQuery, GetActiveClientsResponse>
{
    public GetActiveClientsQueryHandler()
    {

    }

    public Task<GetActiveClientsResponse> Handle(GetActiveClientsQuery request, CancellationToken token)
    {
        throw new System.NotImplementedException();
    }
}
