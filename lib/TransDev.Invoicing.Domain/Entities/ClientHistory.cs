namespace TransDev.Invoicing.Domain.Entities;

public record ClientHistory
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public Client Parent { get; set; }
    public long AuditTrailId { get; set; }
    public AuditTrail AuditTrail { get; set; }
    public long? UpdatedAuditTrailId { get; set; }
    public AuditTrail UpdatedAuditTrail { get; set; }
    public int SystemAddressId { get; set; }
    public SystemAddress PrimaryAddress { get; set; }
    public int SystemBillingAddressId { get; set; }
    public SystemAddress PrimaryBillingAddress { get; set; }
    public string Name { get; set; }
    public int PrimaryContactId { get; set; }
    public Contact PrimaryContact { get; set; }
    public int PrimaryBillingContactId { get; set; }
    public Contact PrimaryBillingContact { get; set; }
}
