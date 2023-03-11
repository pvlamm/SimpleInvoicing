namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

public record Invoice
{
    public int Id { get; init; }
    public Guid PublicId { get; init; } = Guid.NewGuid();
    public string Number { get; init; }
    public int ClientId { get; init; }
    public Client Client { get; init; }
    public int ContactId { get; init; }
    public Contact Contact { get; init; }
    public ICollection<InvoiceDetail> Details { get; init; } = new HashSet<InvoiceDetail>();
    public ICollection<InvoiceStatusHistory> StatusHistory { get; init; } = new HashSet<InvoiceStatusHistory>();
}
