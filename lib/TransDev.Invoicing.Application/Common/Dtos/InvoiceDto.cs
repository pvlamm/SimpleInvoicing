namespace TransDev.Invoicing.Application.Common.Dtos;

using System;

using TransDev.Invoicing.Domain.Enums;

public class InvoiceDto
{
    public Guid PublicId { get; set; }
    public Guid ClientPublicId { get; set; }
    public Guid PrimaryContactPublicId { get; set; }
    public Guid PrimaryBillingContactPublicId { get; set; }
    public InvoiceStatusType InvoiceStatus { get; set; }
}
