using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Application.Items.Queries.GetActiveItems
{
    public class GetActiveItemsQuery : IRequest<GetActiveItemsResponse>
    {
        public string SearchQuery { get; set; }
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }

    public class GetActiveItemsQueryHandler : IRequestHandler<GetActiveItemsQuery, GetActiveItemsResponse>
    {
        public Task<GetActiveItemsResponse> Handle(GetActiveItemsQuery request, CancellationToken token)
        {
        }
    }
}
