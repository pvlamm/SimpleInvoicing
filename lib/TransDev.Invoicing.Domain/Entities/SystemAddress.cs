namespace TransDev.Invoicing.Domain.Entities;

public record SystemAddress
{
    public long Id { get; set; }
    public string Address { get; set; }
    public int SystemCityId { get; set; }
    public SystemCity City { get; set; }
    public string SystemStateId { get; set; }
    public SystemState State { get; set; }
    public string ZipCode { get; set; }
}
