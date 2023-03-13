namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Client
{
    public int Id { get; init; }
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public ClientType ClientType { get; set; }
    public IEnumerable<ClientHistory> History { get; set; } = new HashSet<ClientHistory>();
    public IEnumerable<Contact> Contacts { get; set; } = new HashSet<Contact>();
    public IEnumerable<Invoice> Invoices { get; set; } = new HashSet<Invoice>();
}
