namespace TransDev.Invoicing.Domain.Entities;

public record SystemCity
{
    public int Id { get; set; }
    public string SystemStateId { get; set; }
    public SystemState State { get; set; }
    public string Name { get; set; }
}
