namespace TransDev.Invoicing.Application.Invoices.Queries.GetInvoices;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Abstracts;

public class GetInvoicesQuery : PaginationBase, IRequest<GetInvoicesQueryResult>
{
}

public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, GetInvoicesQueryResult>
{
    public Task<GetInvoicesQueryResult> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }
}
