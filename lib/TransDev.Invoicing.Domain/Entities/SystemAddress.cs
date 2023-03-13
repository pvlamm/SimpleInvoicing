namespace TransDev.Invoicing.Domain.Entities;

public record SystemAddress
{
    public long Id { get; init; }
    public string SystemStateId { get; set; }
    public virtual SystemState State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
}
