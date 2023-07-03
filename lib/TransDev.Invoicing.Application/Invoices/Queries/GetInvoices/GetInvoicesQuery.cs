namespace TransDev.Invoicing.Application.Invoices.Queries;

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.EntityFrameworkCore;

using TransDev.Invoicing.Application.Common.Abstracts;
using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class GetInvoicesQuery : PaginationBase, IRequest<GetInvoicesQueryResult>
{
}

public class GetInvoicesQueryHandler : IRequestHandler<GetInvoicesQuery, GetInvoicesQueryResult>
{
    private readonly IInvoiceService _invoiceService;

    public GetInvoicesQueryHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
    }
    public async Task<GetInvoicesQueryResult> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
    {
        //var invoiceResults = await _invoiceService
        //    .Invoices
        //    .Skip((request.PageSize - 1) * request.PageNumber)
        //    .Take(request.PageSize)
        //    .ToListAsync(cancellationToken);

        // Just empty return FOR NOW!
        return new GetInvoicesQueryResult
        {
            Invoices = new InvoiceDto[5]
        };
    }
}
