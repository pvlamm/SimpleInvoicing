namespace TransDev.Invoicing.Domain.Entities;

public record ItemHistory
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public virtual Item Parent { get; set; }
    public long AuditTrailId { get; set; }
    public virtual AuditTrail AuditTrail { get; set; }
    public long? UpdatedAuditTrailId { get; set; }
    public virtual AuditTrail UpdatedAuditTrail { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
