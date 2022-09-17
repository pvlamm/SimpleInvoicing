namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public sealed record InvoiceHistory : HistoryEntityBase
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public Invoice Parent { get; set; }
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}
