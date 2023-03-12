namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.Enums;

public record SystemInvoiceStatus
{
    public byte Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public InvoiceStatusType StatusType { get; init; } = InvoiceStatusType.Detailling;
}
