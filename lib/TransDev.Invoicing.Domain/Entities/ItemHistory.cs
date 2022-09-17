namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ItemHistory : HistoryEntityBase
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public virtual Item Parent { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
