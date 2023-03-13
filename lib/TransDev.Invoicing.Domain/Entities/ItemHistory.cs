namespace TransDev.Invoicing.Domain.Entities;

using System.Collections.Generic;

using TransDev.Invoicing.Domain.BaseEntities;

public record ItemHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; set; }
    public virtual Item Parent { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
}
