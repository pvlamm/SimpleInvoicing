namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ClientHistory : HistoryEntityBase
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public Client Parent { get; set; }
    public int PrimarySystemAddressId { get; set; }
    public SystemAddress PrimaryAddress { get; set; }
    public int BillingSystemAddressId { get; set; }
    public SystemAddress BillingAddress { get; set; }
    public int PrimaryContactId { get; set; }
    public Contact PrimaryContact { get; set; }
    public int PrimaryBillingContactId { get; set; }
    public Contact PrimaryBillingContact { get; set; }
    public bool IsActive { get; set; } = true;
    public string Name { get; set; }
}
