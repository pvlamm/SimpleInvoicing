namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

public record Invoice
{
    public int Id { get; set; }
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public string Number { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public IEnumerable<InvoiceHistory> History { get; set; }
    public IEnumerable<InvoiceStatus> Status { get; set; }
}
