namespace TransDev.Invoicing.Domain.Entities;

public record SystemInvoiceStatus
{
    public byte Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsClosed { get; set; } = false;
}
