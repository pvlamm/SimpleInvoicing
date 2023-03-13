namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record InvoiceStatusHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; set; }
    public virtual Invoice Parent { get; set; }
    public byte SystemInvoiceStatusId { get; set; }
    public SystemInvoiceStatus Status { get; set; }
}
