namespace TransDev.Invoicing.Domain.Entities;

public record SystemPaymentTerm
{
    public byte Id { get; init; }
    public string Name { get; init; }
    public short DueInDays { get; init; }
}
