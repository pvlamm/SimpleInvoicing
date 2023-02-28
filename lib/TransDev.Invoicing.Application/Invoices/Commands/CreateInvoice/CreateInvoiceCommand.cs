namespace TransDev.Invoicing.Application.Invoices.Commands.CreateInvoice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    public class CreateInvoiceCommand : IRequest<CreateInvoiceResponse>
    {
        public int ClientId { get; set; }
        public int ContactId { get; set; }


    }

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, CreateInvoiceResponse>
    {
        public CreateInvoiceCommandHandler()
        {

        }

        public Task<CreateInvoiceResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
