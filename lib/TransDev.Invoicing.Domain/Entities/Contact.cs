namespace TransDev.Invoicing.Domain.Entities;

public record Contact
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
}
