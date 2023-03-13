namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record InvoiceStatusHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; init; }
    public virtual Invoice Parent { get; init; }
    public byte SystemInvoiceStatusId { get; init; }
    public SystemInvoiceStatus Status { get; init; }
}
