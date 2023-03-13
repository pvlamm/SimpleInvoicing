namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ClientHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; set; }
    public virtual Client Parent { get; set; }
    public long PrimarySystemAddressId { get; set; }
    public virtual SystemAddress PrimaryAddress { get; set; }
    public long BillingSystemAddressId { get; set; }
    public virtual SystemAddress BillingAddress { get; set; }
    public int PrimaryContactId { get; set; }
    public virtual Contact PrimaryContact { get; set; }
    public int PrimaryBillingContactId { get; set; }
    public virtual Contact PrimaryBillingContact { get; set; }
    public bool IsActive { get; set; } = true;
    public string Name { get; set; }
}
