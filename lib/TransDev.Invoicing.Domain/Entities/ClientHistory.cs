namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ClientHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; init; }
    public Client Parent { get; init; }
    public long PrimarySystemAddressId { get; init; }
    public SystemAddress PrimaryAddress { get; init; }
    public long BillingSystemAddressId { get; init; }
    public SystemAddress BillingAddress { get; init; }
    public int PrimaryContactId { get; init; }
    public Contact PrimaryContact { get; init; }
    public int PrimaryBillingContactId { get; init; }
    public Contact PrimaryBillingContact { get; init; }
    public bool IsActive { get; init; } = true;
    public string Name { get; init; }
}
