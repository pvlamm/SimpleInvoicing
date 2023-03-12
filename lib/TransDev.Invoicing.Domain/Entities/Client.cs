namespace TransDev.Invoicing.Domain.Entities;

using System;
using System.Collections.Generic;

using TransDev.Invoicing.Domain.Enums;

public record Client
{
    public int Id { get; init; }
    public Guid PublicId { get; init; } = Guid.NewGuid();
    public ClientType ClientType { get; init; }
    public IEnumerable<ClientHistory> History { get; init; } = new HashSet<ClientHistory>();
    public IEnumerable<Contact> Contacts { get; init; } = new HashSet<Contact>();
    public IEnumerable<Invoice> Invoices { get; init; } = new HashSet<Invoice>();
}
