namespace TransDev.Invoicing.Domain.Entities;

public record InvoiceDetail
{
    public long Id { get; init; }
    public int ParentId { get; set; }
    public virtual Invoice Parent { get; set; }
    public long ItemId { get; set; }
    public virtual ItemHistory Item { get; set; }
    public short SequenceNumber { get; set; }
    public decimal Cost { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
}
