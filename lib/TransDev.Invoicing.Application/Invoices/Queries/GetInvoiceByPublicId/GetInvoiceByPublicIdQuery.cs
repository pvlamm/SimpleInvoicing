namespace TransDev.Invoicing.Application.Invoices.Queries;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Interfaces;

public class GetInvoiceByPublicIdQuery : IRequest<GetInvoiceByPublicIdQueryResponse>
{
    public Guid PublicId { get; set; }
}

public class GetInvoiceByPublicIdQueryHandler : IRequestHandler<GetInvoiceByPublicIdQuery, GetInvoiceByPublicIdQueryResponse>
{
    private readonly IInvoiceService _invoiceService;
    public GetInvoiceByPublicIdQueryHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
    }

    public async Task<GetInvoiceByPublicIdQueryResponse> Handle(GetInvoiceByPublicIdQuery request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceService.GetInvoiceByPublicIdAsync(request.PublicId, cancellationToken);

        return new GetInvoiceByPublicIdQueryResponse
        {

        };
    }
}
