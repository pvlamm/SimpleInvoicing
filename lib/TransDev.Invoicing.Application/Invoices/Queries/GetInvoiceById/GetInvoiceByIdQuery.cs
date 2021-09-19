using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TransDev.Invoicing.Application.Invoices.Queries.GetInvoiceById
{
    public class GetInvoiceByIdQuery : IRequest<GetInvoiceByIdResponse>
    {
        public Guid PublicId { get; set; }
    }

    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, GetInvoiceByIdResponse>
    {
        private readonly IMapper _mapper;

        public GetInvoiceByIdQueryHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<GetInvoiceByIdResponse> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
