namespace TransDev.Invoicing.Application.Account.Queries
{
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class GetActiveAccountsQuery : IRequest<GetActiveAccountsPagination>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetActiveAccountsQueryHandler : IRequestHandler<GetActiveAccountsQuery, GetActiveAccountsPagination>
    {
        public GetActiveAccountsQueryHandler()
        {
            
        }

        public Task<GetActiveAccountsPagination> Handle(GetActiveAccountsQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
