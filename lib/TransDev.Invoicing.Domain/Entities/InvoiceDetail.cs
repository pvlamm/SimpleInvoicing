namespace TransDev.Invoicing.Domain.Entities
{
    public record InvoiceDetail
    {
        public long Id { get; init; }
        public long ParentId { get; init; }
        public virtual InvoiceHistory Parent { get; init; }
        public long ItemId { get; init; }
        public virtual ItemHistory Item { get; init; }
        public short SequenceNumber { get; init; }
        public decimal Cost { get; init; }
        public decimal Quantity { get; init; }
        public decimal Price { get; init; }
    }
}
