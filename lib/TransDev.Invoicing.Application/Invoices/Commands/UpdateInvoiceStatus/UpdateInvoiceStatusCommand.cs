namespace TransDev.Invoicing.Application.Invoices.Commands;

using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Interfaces;
using TransDev.Invoicing.Domain.Entities;

public class UpdateInvoiceStatusCommand : IRequest<bool>
{
    public Guid PublicId { get; set; }
    public byte SystemInvoiceStatusId { get; set; }
}

public class UpdateInvoiceStatusCommandHandler : IRequestHandler<UpdateInvoiceStatusCommand, bool>
{
    private readonly IInvoiceService _invoiceService;

    public UpdateInvoiceStatusCommandHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
    }

    public async Task<bool> Handle(UpdateInvoiceStatusCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _invoiceService.GetInvoiceByPublicIdAsync(request.PublicId, cancellationToken);

        return await _invoiceService.UpdateInvoiceStatusAsync(invoice.Id, request.SystemInvoiceStatusId, cancellationToken);
    }
}
