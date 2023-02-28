namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.BaseEntities;

public sealed record InvoiceHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; init; }
    public Invoice Parent { get; init; }
    public int ContactId { get; init; }
    public Contact Contact { get; init; }
    public IEnumerable<InvoiceDetail> Details { get; init; }
}
