namespace TransDev.Invoicing.Application.Invoices.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using TransDev.Invoicing.Application.Common.Dtos;
using TransDev.Invoicing.Application.Common.Interfaces;

public class UpdateInvoiceCommand : IRequest<bool>
{
    public InvoiceDto Invoice { get; set; }
}

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, bool>
{
    private readonly IInvoiceService _invoiceService;

    public UpdateInvoiceCommandHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService ?? throw new ArgumentNullException(nameof(invoiceService));
    }

    public async Task<bool> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        // need to implement this
        // need to better define InvoiceDto as well
        //var invoice = request.Invoice.ConvertToInvoice();

        return await _invoiceService.UpdateInvoiceAsync(new Domain.Entities.Invoice(), cancellationToken);
    }
}
