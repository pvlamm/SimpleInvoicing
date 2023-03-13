namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.Enums;

public record SystemInvoiceStatus
{
    public byte Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public InvoiceStatusType StatusType { get; set; } = InvoiceStatusType.Detailling;
}
