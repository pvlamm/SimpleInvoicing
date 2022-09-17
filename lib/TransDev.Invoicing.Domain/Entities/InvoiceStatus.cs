namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public sealed record InvoiceStatus : HistoryEntityBase
{
    public long Id { get; set; }
    public byte ParentId { get; set; }
    public SystemInvoiceStatus Parent { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public long InvoiceHistoryId { get; set; }
    public InvoiceHistory InvoiceHistory { get; set; }
}
