namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ContactHistory : HistoryEntityBase
{
    public long Id { get; init; }
    public int ParentId { get; init; }
    public virtual Contact Parent { get; init; }
    public long SystemAddressId { get; init; }
    public virtual SystemAddress Address { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string EmailAddress { get; init; }
    public string PhoneNumber { get; init; }
}
