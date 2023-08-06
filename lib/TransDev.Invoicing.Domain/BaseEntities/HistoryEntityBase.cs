namespace TransDev.Invoicing.Domain.BaseEntities;

using TransDev.Invoicing.Domain.Entities;

public class HistoryEntityBase
{
    public long AuditTrailId { get; set; }
    public AuditTrail AuditTrail { get; set; }
    public long? UpdatedAuditTrailId { get; set; }
    public AuditTrail UpdatedAuditTrail { get; set; }
}
