namespace TransDev.Invoicing.Domain.Entities;

using TransDev.Invoicing.Domain.BaseEntities;

public record ContactHistory : HistoryEntityBase
{
    public long Id { get; set; }
    public int ParentId { get; set; }
    public Contact Parent { get; set; }
    public int SystemAddressId { get; set; }
    public SystemAddress Address { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
