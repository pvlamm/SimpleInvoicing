namespace TransDev.Invoicing.Application.Common.Models;

using System;

using TransDev.Invoicing.Domain.Enums;

public class GetInvoicesResultModel
{
    public Guid PublicId { get; set; }
    public string ClientName { get; set; }
    public string ContactName { get; set; }
    public string Number { get; set; }
    public InvoiceStatusType InvoiceStatus { get; set; }
    public DateOnly CreatedDate { get; set; }
    public DateOnly? InvoicedDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public int Amount { get; set; }
}
