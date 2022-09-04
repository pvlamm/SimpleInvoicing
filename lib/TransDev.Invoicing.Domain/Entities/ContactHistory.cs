namespace TransDev.Invoicing.Domain.Entities;

public record ContactHistory
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public Contact Parent { get; set; }
    public long AuditTrailId { get; set; }
    public AuditTrail AuditTrail { get; set; }
    public long? UpdatedAuditTrailId { get; set; }
    public AuditTrail UpdatedAuditTrail { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SystemAddressId { get; set; }
    public SystemAddress Address { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
