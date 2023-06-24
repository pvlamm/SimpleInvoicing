namespace TransDev.Invoicing.Application.Invoices.Queries;

using TransDev.Invoicing.Application.Common.Dtos;

public class GetInvoiceByPublicIdQueryResponse
{
    public InvoiceDto Invoice { get; set; }
    public InvoiceDetailDto[] InvoiceDetails { get; set; }
}
