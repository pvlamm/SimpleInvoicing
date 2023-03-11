namespace TransDev.Invoicing.Domain.Entities;

public record SystemAddress
{
    public long Id { get; init; }
    public string SystemStateId { get; init; }
    public SystemState State { get; init; }
    public string City { get; init; }
    public string Address { get; init; }
    public string ZipCode { get; init; }
}
