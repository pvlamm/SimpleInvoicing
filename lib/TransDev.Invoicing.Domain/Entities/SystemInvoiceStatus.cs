namespace TransDev.Invoicing.Domain.Entities;

public record SystemInvoiceStatus
{
    public byte Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public bool IsClosed { get; init; } = false;
    public bool IsCancelled { get; init; } = false;
}
